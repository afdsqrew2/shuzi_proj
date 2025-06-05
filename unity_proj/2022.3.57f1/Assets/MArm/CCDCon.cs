using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCDCon : MonoBehaviour  //��е�ۿ��ƽű�
{


    //CCD����

    [SerializeField]
    Transform pbone;//������̨�ڵ�

    [SerializeField]
    int depth = 0;//�ڵ����  - �ű����ڵ������ǳ�̨������depth�����Ľڵ�Ϊ��е��

    [SerializeField]
    int ccdDepth = 5;//CCD��������

    [SerializeField]
    float rotateTime = 3.0f;//��תƥ��ʱ��

    float nowTime = 0;//��ǰʱ��

    List<Transform> bones;//�����ڵ�

    List<Transform> arms;//�۽ڵ�

    Transform bonePoint;//����ĩ�˵�

    List<Quaternion> baseRotation;//��ʼ����

    List<Quaternion> armRotation;//��е�۽ڵ�ĳ�ʼ����

    //״̬���  - ��ȡ���

    public enum ArmState
    {
        rotate, //������ת
        stati //�Ѿ�ֹ�� ���Ա�������
    }

    ArmState armState = ArmState.stati;

    public ArmState AState {
        get {
            return armState;
        }
    }

    bool onPhyCheck = false;//���ڿ���������ײ���
    bool isCatch = false;//�Ƿ��ȡ����Ŀ�� ---  ������Updateλ��ƥ����ɺ�ָʾ��һ������
    catchObj catchTar = null;//��ȡĿ��

    public bool IsCatch {
        get {
            return isCatch;
        }
    }

    [SerializeField]
    Transform catchPoint; //ĩ��λ�� - ���ڼ�ȡ������ƶ�ʱ��λ��ƥ��

    [SerializeField]
    Transform boneEndPoint;//����ĩ��λ�� - ���ڷ�������ʱ���ж��Ƿ��ܷŵ�Ŀ��λ����

    Vector3 delVec;//��ĩ��λ��Ĳ���
    Vector3 roVec;//ת������
    float cproAngle;//ÿ����Ҫ��ת�ĽǶ�


    [System.Serializable]
    class pointRoClamp
    {
        public bool onClamp;
        public float maxro;
        public float minro;
    }


    [SerializeField]
    List<pointRoClamp> roclamps;


    //�������

    Animator animator;

    int openHash = Animator.StringToHash("open");
    int closeHash = Animator.StringToHash("close");
    int stopHash = Animator.StringToHash("stop");
    int resetHash = Animator.StringToHash("reset");

    private void Awake()
    {
        arms = new List<Transform>();
        bones = new List<Transform>();
        baseRotation = new List<Quaternion>();
        armRotation = new List<Quaternion>();

        animator = gameObject.GetComponent<Animator>();

        Transform pre = gameObject.transform.GetChild(0);//������1������FPoint
        Transform preb = pbone.transform.GetChild(0);

        catchTar = null;

        armRotation.Add(gameObject.transform.rotation);

        for (int i = 0; i < depth; ++i) {
            pre = pre.GetChild(0);
            preb = preb.GetChild(0);

            arms.Add(pre);
            bones.Add(preb);
            baseRotation.Add(preb.transform.localRotation);
            armRotation.Add(pre.transform.localRotation);
        }

        bonePoint = preb.GetChild(0);//����ĩ�˵�

    }


    Vector3 bonetopoint;//����ָ��ĩ�˵�����
    Vector3 bonetotar;//����ָ��Ŀ�������
    Vector3 vec;
    float angle;//��ת�Ƕ�
    Vector3 axis;//ת��

    public void ccdgo(Vector3 p, catchObj tar = null)  //����CCD���Թ�����������pλ��
    {

        if (armState == ArmState.rotate)//���������תӦ����
            return;

        if (isCatch == (tar != null)) //δץס���������Ŀ�꣬��ץס���������Ŀ����з���
            return;

        //������̨��׼
        pbone.LookAt(new Vector3(p.x, pbone.transform.position.y, p.z), Vector3.up);


        //

        if (catchTar == null) { //��ȡ����
            catchTar = tar;//���ü�ȡĿ��
            animator.SetTrigger(openHash);//��צ��

        }
        else { //��������
            catchTar.Cld.enabled = false;//��ʼ�ƶ���ȡ����ʱ���ر���ײ
            p += catchTar.PutOverVec;//���������߶�

            //����λ��&��תƥ������
            delVec = catchTar.transform.position - catchPoint.position;
            cproAngle = Vector3.Angle(transform.forward, pbone.forward) / rotateTime;
            roVec = Vector3.Cross(transform.forward, pbone.forward).normalized;
        }


        //�����ڵ��ʼ����ת
        for (int i = 0; i < depth; ++i)
            bones[i].transform.localRotation = baseRotation[i];

        //

        //CCD��������ڵ�
        for (int i = 0; i < ccdDepth; ++i) { //��������

            for (int j = 0; j < depth; ++j) { //���μ���ÿ������������

                //�ڵ�ѡ��
                if (Vector3.Distance(p, gameObject.transform.position) < 2.0f && j == 0) { //���Ŀ���λ�ù�����CCD����������һ���ڵ�
                    continue;
                }

                vec = bones[j].InverseTransformPoint(bonePoint.position);//ת�뱾������
                bonetopoint = new Vector3(vec.x, 0, vec.z).normalized;//Y��ǿ�ƹ�0����Ϊƽ������ת

                vec = bones[j].InverseTransformPoint(p);//ת�뱾������
                bonetotar = new Vector3(vec.x, 0, vec.z).normalized;//Y��ǿ�ƹ�0����Ϊƽ������ת

                angle = Vector3.Angle(bonetopoint, bonetotar);

                axis = Vector3.Cross(bonetopoint, bonetotar).normalized;

                bones[j].Rotate(axis, angle);


                ////�ڵ���������
                //if (j == 0) {
                //    //��һʱ���Y����ת��һ��Clamp
                //    bones[0].localEulerAngles = new Vector3(0, Mathf.Clamp(bones[0].localEulerAngles.y, -60.0f, 130.0f), 0);
                //    //��������ڵ�û��Ļ�����ô x z local��ת�϶���0������ bones[0].localEulerAngles.x/.z ����д
                //}
                //else if (j == 1 || j == 2) {
                //    bones[j].localEulerAngles = new Vector3(0, Mathf.Clamp(bones[j].localEulerAngles.y, 0, 120.0f), 0);
                //}
                //else if (j == 3) {
                //    bones[3].localEulerAngles = new Vector3(0, Mathf.Clamp(bones[3].localEulerAngles.y, -20.0f, 20.0f), 0);
                //}

                if (roclamps.Count > j && roclamps[j].onClamp) {
                    bones[j].localEulerAngles = new Vector3(0, Mathf.Clamp(bones[j].localEulerAngles.y, roclamps[j].minro, roclamps[j].maxro), 0);
                }
            }


        }

        //������е�۽ڵ�ƥ��

        //��е��ֱ��ƥ��
        //gameObject.transform.rotation = pbone.rotation;

        //for (int i = 0; i < depth; ++i)
        //    arms[i].rotation = bones[i].rotation;


        //����״̬ Update ��ֵƥ��


        if (IsCatch && Vector3.Distance(p, boneEndPoint.position) > 0.1f) {//��ClampӰ�񣬷���Ŀ��ʱ��Ԥ���ж��ܷ�ŵ�ָ��λ��
            //����Ų��� Reset��е��
            catchTar.Rbdy.isKinematic = false;//����ָ�
            catchTar.Cld.enabled = true;
            catchTar = null;
            isCatch = false;
            animator.SetTrigger(resetHash);//צ�ӻָ�Ĭ��״̬
            armState = ArmState.stati;
            ccdReset();//���û�е����̬

            Debug.Log("�޷���ɷ��ã�����");
        }
        else {//��������Update��ת�ĳ�ʼ��

        armState = ArmState.rotate;
        nowTime = 0;

        armRotation[0] = gameObject.transform.rotation;//��¼��̨����

        for (int i = 1; i <= depth; ++i)
            armRotation[i] = arms[i - 1].localRotation;

        }
    }


    public void ccdReset() //��λ
    {
        if (armState == ArmState.rotate) return;//���������תӦ����

        //��׼��̨
        pbone.rotation = gameObject.transform.rotation;

        //������λ
        for (int i = 0; i < depth; ++i)
            bones[i].localRotation = baseRotation[i];

        //����״̬ Update ��ֵƥ��

        armState = ArmState.rotate;
        nowTime = 0;

        armRotation[0] = gameObject.transform.rotation;//��¼��̨����

        for (int i = 1; i <= depth; ++i)
            armRotation[i] = arms[i - 1].localRotation;
    }

    float lerp;
    private void Update()
    {
        if (!onPhyCheck&&armState == ArmState.rotate) {//������תƥ���
            nowTime += Time.deltaTime;
            if (nowTime >= rotateTime) { //ƥ���Ѿ����

                //���ƥ�� ������̬
                gameObject.transform.rotation = pbone.rotation;

                for (int i = 0; i < depth; ++i)
                    arms[i].localRotation = bones[i].localRotation;


                //���� isCatch ������һ������
                if (catchTar) { //�м�ȡĿ����Ҫ������һ������

                    if (isCatch) { //Ӧ���ͷż�ȡĿ��
                        //catchTar.parent = null;//�ͷ�Ŀ��
                        catchTar.Rbdy.isKinematic = false;//����ָ�
                        catchTar.Cld.enabled = true;
                        catchTar = null;
                        isCatch = false;
                        animator.SetTrigger(resetHash);//צ�ӻָ�Ĭ��״̬
                        armState = ArmState.stati;
                        ccdReset();//���û�е����̬

                        

                    }
                    else {//Ӧ����ɼ�ȡ����
                        
                        //��ȡ����&������
                        animator.SetTrigger(closeHash);//ִ�к�ץ����
                        onPhyCheck = true;//����������

                    }
                }else
                    armState = ArmState.stati;//����Ҫ��һ�� ����״̬Ϊ��ֹ

            }
            else { //������תƥ��
                lerp = nowTime / rotateTime;

                gameObject.transform.rotation = Quaternion.Slerp(armRotation[0], pbone.rotation, lerp);

                for (int i = 1; i <= depth; ++i)
                    arms[i - 1].localRotation = Quaternion.Slerp(armRotation[i], bones[i - 1].localRotation, lerp);

                //ץȡĿ���λ�ø���ƥ��
                if (isCatch && catchTar) {
                    catchTar.transform.RotateAround(transform.position, roVec, Time.deltaTime*cproAngle);
                    catchTar.transform.position = catchPoint.position + delVec;

                }
            }
        }

        

        
        
    }

    private void OnTriggerStay(Collider other) //��ײ����ȡĿ������
    {
        if (!isCatch&&onPhyCheck&&other.CompareTag("obj")&&catchTar.Cld == other) {
            isCatch = true;
            onPhyCheck = false;
            animator.SetTrigger(stopHash);
            armState = ArmState.stati;
            catchTar.Rbdy.isKinematic = true;//���徲̬��
           
        }
    }


    public void catchCheck() //Closeִ�е���� �Ƿ��ȡ��
    {
        if (onPhyCheck && !isCatch) { //ץȡʧ��
            isCatch = false;
            catchTar = null;
            onPhyCheck = false;
            animator.SetTrigger(resetHash);
            armState = ArmState.stati;
            ccdReset();
            Debug.Log("��ȡʧ�ܣ�����");
        }

    }




}

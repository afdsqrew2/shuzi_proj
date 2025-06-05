using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FPCCamCC : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    public float rotateSpeedX;
    public float rotateSpeedY;
    public float LerpSpeed;

    //distanceScaleTargetValue��ʾһ��ʼ����Ŀ��λ�õľ���̶ȣ�
    //��ֵԽ�����ԽԶ����ֵԽС����Խ��������ű������еļ��㹫ʽ�йأ�
    public float distanceScaleTargetValue;
    private float distanceScaleCurrentValue;

    /// <summary>
    /// �޶����ŵ�������Сֵ
    /// </summary>
    public float minDistance;
    public float maxDistance;

    /// <summary>
    /// �޶�Y��������ת�ĽǶȵ�������
    /// </summary>
    public float minRotateYClampValue;
    public float maxRotateYClampValue;

    //��ȡ�µ�ǰĿ��λ��,����ҪΧ�Ƶ����壬��Ҫ��ʾ��
    public Transform targetTrans;

    //��¼һ���ʼ�ı�����ŷ����
    private float startDistanceScaleValue;
    private Vector3 startEulerAngles;

    public GameObject cameraGo;



    // Start is called before the first frame update
    void Start()
    {

        startEulerAngles = transform.eulerAngles;
        startDistanceScaleValue = distanceScaleTargetValue;
        ResetCameraState();
        //mouseY = startEulerAngles.y;//��ȡ�ʼangleY��ֵ
        //mouseX = startEulerAngles.x;//��ȡ�ʼangleX��ֵ
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            mouseX += Input.GetAxis("Mouse X") * rotateSpeedX;
            mouseY -= Input.GetAxis("Mouse Y") * rotateSpeedY;//mouseY�Ƿ��ŵģ�����Ҫȡ��ֵ
            mouseY = Mathf.Clamp(mouseY, minRotateYClampValue, maxRotateYClampValue);
            //mathf.Clamp()�������Խ�ֵ�޶���������Сֵ֮��
        }
        else if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            distanceScaleTargetValue += -Input.GetAxis("Mouse ScrollWheel");
            distanceScaleTargetValue = Mathf.Clamp(distanceScaleTargetValue, 0, 1);
        }

    }

    /// <summary>
    /// ���������Ҫ�����������ƶ���֮���ٽ��и��£���תҪ����lateupdate��
    /// </summary>
    private void LateUpdate()
    {
        //��ŷ����תΪ��Ԫ��
        Quaternion targetRotation = Quaternion.Euler(mouseY, mouseX, 0);
        //���ƶ�Ч������ƽ��
        //��ֵ���㣬����ת�Ƕ���Ŀ����תֵ���в�ֵ/��ֵ�ٶ���ÿ��Ϊ��λ
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * LerpSpeed);
        //��Ԫ����������ˡ�����λ�ó���Ŀ��λ�õ���������Ԫ��
        Vector3 targetPosition = transform.rotation * new Vector3(0, 0, -GetCurrentPos()) + targetTrans.position;//ZֵҪ�Ǹ��Ĳſ��ԣ���Ϊ�������������󷽣�zֵҪ��Ŀ��ֵС
        transform.position = targetPosition;
    }

    private float GetCurrentPos()
    {
        distanceScaleCurrentValue = Mathf.Lerp(distanceScaleCurrentValue, distanceScaleTargetValue, Time.deltaTime * LerpSpeed);
        return minDistance + (maxDistance - minDistance) * distanceScaleTargetValue;
    }



    public void ResetCameraState()
    {
        cameraGo.SetActive(true);
        distanceScaleCurrentValue = distanceScaleTargetValue = startDistanceScaleValue;
        //��һ��ʼ��λ�ýǶȽ��г�ʼ�����趨���洢
        mouseX = transform.eulerAngles.y;
        mouseY = transform.eulerAngles.x;
        distanceScaleCurrentValue = distanceScaleTargetValue;
    }
}

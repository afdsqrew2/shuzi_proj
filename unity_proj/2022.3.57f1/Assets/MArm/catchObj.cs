using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class catchObj : MonoBehaviour
{
    Collider cld;
    Rigidbody rbdy;

    [SerializeField]
    float catchOverHeight = 0f;//��������ĵ��������ĸ߶�

    [SerializeField]
    float putOverHeight = 0f;//��Է���λ����Ҫ�����ĸ߶�


    public Collider Cld {
        get {
            return cld;
        }
    }

    public Rigidbody Rbdy {
        get {
            return rbdy;
        }
    }

    public Vector3 CatchCenterPoint { //��ȡ���屻��ȡ������λ�� ��������
        get {
            return transform.position + catchOverHeight * transform.up;
        }
    }

    public Vector3 PutOverVec { //������Է���λ��Ӧ�������ĸ߶�����
        get {
            return Vector3.up * putOverHeight;
        }
    }


    private void Awake()
    {
        cld = gameObject.GetComponent<Collider>();
        rbdy = gameObject.GetComponent<Rigidbody>();
    }


}

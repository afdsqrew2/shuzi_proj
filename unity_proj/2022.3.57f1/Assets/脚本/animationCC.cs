using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class animationCC : MonoBehaviour
{
    public Animator discharge;
    public Animator station1;
    public Animator station2;
    public Animator station3;
    public Animator station4;
    public Animator AGV;

    
    public void OverallPre()//ȫ������(����Ԥ��)
    {
        Discharge();
        Invoke("stationOne", 15);
        Invoke("stationTwo", 143);
        Invoke("stationThree", 226);
        Invoke("stationFour", 276);
        Invoke("Feedstock", 396);
        //--15--128--83--50--120--22
    }

    public void Discharge()//����
    {
        ResetBoolAndSpeed();
        discharge.speed = 1.0f;
        discharge.SetBool("out",true);
    }
    

    public void Feedstock()//����
    {
        ResetBoolAndSpeed();
        discharge.speed = 1.0f;
        discharge.SetBool("enter", true);
    }
    public void stationOne()//�ӹ�
    {
        ResetBoolAndSpeed();
        station1.speed = 1.0f;
        station1.SetBool("one", true);
    }

    public void stationTwo()//���
    {
        ResetBoolAndSpeed();
        station2.speed = 1.0f;
        station2.SetBool("two", true);
        AGV.speed = 1.0f;
        AGV.SetBool("two", true);
    }

    public void stationThree()//װ��
    {
        ResetBoolAndSpeed();
        station3.speed = 1.0f;
        station3.SetBool("three", true);
    }

    public void stationFour()//��װ
    {
        ResetBoolAndSpeed();
        station4.speed = 1.0f;
        station4.SetBool("four", true);
        AGV.speed = 1.0f;
        AGV.SetBool("four", true);
    }


    public void ResetBoolAndSpeed()
    {
        discharge.speed = 0f;
        station1.speed = 0f;
        station2.speed = 0f;
        station3.speed = 0f;
        station4.speed = 0f;
        AGV.speed = 0f;
    }









}

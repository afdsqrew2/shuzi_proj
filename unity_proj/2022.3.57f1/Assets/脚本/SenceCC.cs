using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;

public class SenceCC : MonoBehaviour
{
    
    public void LoadSecondaryScene0()
    {
        Application.LoadLevel(2);
    }
    public void LoadSecondaryScene1()
    {
        Application.LoadLevel(3);
    }
    public void LoadSecondaryScene2()
    {
        Application.LoadLevel(4);
    }
    public void LoadSecondaryScene3()
    {
        Application.LoadLevel(5);
    }
    public void LoadSecondaryScene4()
    {
        Application.LoadLevel(6);
    }
    
    
    // �Ӷ�����������������A
    public void ReturnToMainScene()
    {
        Application.LoadLevel(1); ; // ��ʹ������ SceneManager.LoadScene(0);
    }
}

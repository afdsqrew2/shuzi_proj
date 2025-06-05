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
    
    
    // 从二级场景返回主场景A
    public void ReturnToMainScene()
    {
        Application.LoadLevel(1); ; // 或使用索引 SceneManager.LoadScene(0);
    }
}

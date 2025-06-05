using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamAnimt : MonoBehaviour
{
    public Animator roam;

    //private Vector3 RoamCamPos;
    //private Vector3 RoamCamTrans;
    // Start is called before the first frame update
    void Start()
    {
        //RoamCamPos = transform.position;
        //RoamCamTrans = gameObject.transform.eulerAngles;// 获取角色控制器组件
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RoamPlay()
    {
        roam.SetFloat("speed", 1);
    }
}

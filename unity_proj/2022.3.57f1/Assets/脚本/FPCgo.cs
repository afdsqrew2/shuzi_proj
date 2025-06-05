using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCgo : MonoBehaviour
{
    public Camera mainCam;
    public Camera cam01;
    public Camera cam02;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera roamCam;
    public Animator roamCamera;



    // Start is called before the first frame update
    void Start()
    {
        mainCam.gameObject.SetActive(true);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(mainCam);
    }

    // Update is called once per frame
    public void ShowOrHidemainCam()
    {
        mainCam.gameObject.SetActive(true);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(mainCam);
    }

    public void ShowOrHideCam01()
    {
        mainCam.gameObject.SetActive(false);
        cam01.gameObject.SetActive(true);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(cam01);
    }

    public void ShowOrHideCam02()
    {
        mainCam.gameObject.SetActive(false);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(cam02);
    }

    public void ShowOrHideCam1()
    {
        mainCam.gameObject.SetActive(false);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(cam1);
    }

    public void ShowOrHideCam2()
    {
        mainCam.gameObject.SetActive(false);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(cam2);
    }

    public void ShowOrHideCam3()
    {
        mainCam.gameObject.SetActive(false);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(true);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(cam3);
    }

    public void ShowOrHideCam4()
    {
        mainCam.gameObject.SetActive(false);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(true);
        roamCam.gameObject.SetActive(false);
        //SetCameraAsMain(cam4);
    }
    public void RoamAnimation()
    {
        mainCam.gameObject.SetActive(false);
        cam01.gameObject.SetActive(false);
        cam02.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        roamCam.gameObject.SetActive(true);
        //SetCameraAsMain(roamCam);
        roamCamera.SetTrigger("roam");
    }

    public void SetCameraAsMain(Camera camera)
    {
        if (camera != null)
        {
            // 将所有其他摄像机的tag清除
            Camera[] allCameras = Camera.allCameras;
            foreach (Camera cam in allCameras)
            {
                if (cam.CompareTag("MainCamera"))
                {
                    cam.tag = "Untagged";
                }
            }

            // 设置指定摄像机的tag为MainCamera
            camera.tag = "MainCamera";
        }
        else
        {
            Debug.LogError("Camera is not assigned in the inspector!");
        }
    }
}

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

    //distanceScaleTargetValue表示一开始距离目标位置的距离程度，
    //数值越大距离越远，数值越小距离越近（这与脚本中所列的计算公式有关）
    public float distanceScaleTargetValue;
    private float distanceScaleCurrentValue;

    /// <summary>
    /// 限定缩放的最大和最小值
    /// </summary>
    public float minDistance;
    public float maxDistance;

    /// <summary>
    /// 限定Y轴上下旋转的角度的上下限
    /// </summary>
    public float minRotateYClampValue;
    public float maxRotateYClampValue;

    //获取下当前目标位置,（主要围绕的物体，主要显示）
    public Transform targetTrans;

    //记录一下最开始的比例和欧拉角
    private float startDistanceScaleValue;
    private Vector3 startEulerAngles;

    public GameObject cameraGo;



    // Start is called before the first frame update
    void Start()
    {

        startEulerAngles = transform.eulerAngles;
        startDistanceScaleValue = distanceScaleTargetValue;
        ResetCameraState();
        //mouseY = startEulerAngles.y;//获取最开始angleY的值
        //mouseX = startEulerAngles.x;//获取最开始angleX的值
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
            mouseY -= Input.GetAxis("Mouse Y") * rotateSpeedY;//mouseY是反着的，所以要取负值
            mouseY = Mathf.Clamp(mouseY, minRotateYClampValue, maxRotateYClampValue);
            //mathf.Clamp()函数可以将值限定在最大和最小值之间
        }
        else if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            distanceScaleTargetValue += -Input.GetAxis("Mouse ScrollWheel");
            distanceScaleTargetValue = Mathf.Clamp(distanceScaleTargetValue, 0, 1);
        }

    }

    /// <summary>
    /// 摄像机内容要在其他物体移动完之后再进行更新，旋转要放在lateupdate中
    /// </summary>
    private void LateUpdate()
    {
        //将欧拉角转为四元数
        Quaternion targetRotation = Quaternion.Euler(mouseY, mouseX, 0);
        //让移动效果更加平滑
        //插值运算，将旋转角度向目标旋转值进行插值/插值速度以每秒为单位
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * LerpSpeed);
        //四元数与向量相乘—自身位置乘以目标位置的向量或四元数
        Vector3 targetPosition = transform.rotation * new Vector3(0, 0, -GetCurrentPos()) + targetTrans.position;//Z值要是负的才可以，因为摄像机处于物体后方，z值要比目标值小
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
        //将一开始的位置角度进行初始保存设定，存储
        mouseX = transform.eulerAngles.y;
        mouseY = transform.eulerAngles.x;
        distanceScaleCurrentValue = distanceScaleTargetValue;
    }
}

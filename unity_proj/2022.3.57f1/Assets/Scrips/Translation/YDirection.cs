using S7.Net.Types;
using S7.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YDirection : MonoBehaviour
{
    public GameObject 牙叉;
    float realPose;//创建一个全局变量定义移行轴实时坐标位置

    private static DataItem yPose = new DataItem()
    {
        DataType = DataType.DataBlock,
        VarType = VarType.Real,
        DB = 43,
        StartByteAdr = 4,
        BitAdr = 0,
        Count = 1,
        Value = new object()
    };

    public static List<DataItem> yPosition = new List<DataItem>() { yPose };//创建ReadMultipleVars()方法的形参实例

    // Update is called once per frame
    void Update()
    {
        //读取数据
        PLC.storage.ReadMultipleVars(yPosition);
        realPose = float.Parse($"{yPose.Value}");
        Debug.Log(realPose);

        //控制模型运动
        Transform modelTransform = 牙叉.GetComponent<Transform>();//定义模型当前位置(因为牙叉为子物体，这里使用本地坐标)
        Vector3 modelPosition = modelTransform.localPosition;

        Debug.Log(modelPosition);

        //0.4228是初始位姿；除1000是因为unity中单位为m，而实际坐标值单位为mm；+是因为Z轴方向与实际坐标方向相同
        modelPosition.y = (float)(0.4228 + realPose / 1000);

        Debug.Log(modelPosition);

        modelTransform.localPosition = modelPosition;
    }
}

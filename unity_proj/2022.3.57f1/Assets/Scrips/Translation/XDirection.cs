using S7.Net;
using S7.Net.Types;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class XDirection : MonoBehaviour
{
    public GameObject 垂直导轨;
    float realPose;//创建一个全局变量定义移行轴实时坐标位置

    private static DataItem xPose = new DataItem()
    {
        DataType = DataType.DataBlock,
        VarType = VarType.Real,
        DB = 43,
        StartByteAdr = 0,
        BitAdr = 0,
        Count = 1,
        Value = new object()
    };

    public static List<DataItem> xPosition = new List<DataItem>() { xPose };//创建ReadMultipleVars()方法的形参实例

    // Update is called once per frame
    void Update()
    {
        //方式2读取数据方法的调用演示：
        PLC.storage.ReadMultipleVars(xPosition);
        realPose = float.Parse($"{xPose.Value}");
        //Debug.Log(realPose);

        //控制模型运动
        Transform modelTransform = 垂直导轨.GetComponent<Transform>();//获取挂载的模型的Transform组件
        Vector3 modelPosition = modelTransform.localPosition;//获取挂载的模型的本地坐标位置信息（X、Y、Z坐标）
        //330.3628是初始位姿；-是因为移行垂直导轨的运动正方向是Z轴负方向
        modelPosition.z = (float)(330.3628 - realPose);
        modelTransform.localPosition = modelPosition;//实时将改变后的位置信息传入Transform组件，改变模型本地坐标位置
    }

}

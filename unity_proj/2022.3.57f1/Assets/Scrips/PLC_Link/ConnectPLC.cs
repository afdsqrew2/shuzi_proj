using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectPLC : MonoBehaviour
{
    //引用Text组件
    public Text connectStateText;
    public GameObject 智能仓储单元;//无法直接获取脚本，需要通过脚本挂载的对象获取脚本

    //按下按钮时启用脚本
    public void EnableScripts()
    {
        MonoBehaviour[] scripts = 智能仓储单元.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
    }

    //按下按钮时停用脚本
    public void DisableScripts()
    {
        MonoBehaviour[] scripts = 智能仓储单元.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }

    //封装了异常处理逻辑，确保每个 PLC 连接操作独立处理异常。
    private void ExecuteWithExceptionOpen(System.Action action, string plcName)
    {
        try
        {
            action();// 执行传入的操作
        }
        // 捕获异常并记录错误信息
        catch (System.Exception ex)
        {
            Debug.LogError($"Error while opening {plcName} PLC connection: " + ex.Message);
        }
    }

    //次打开多个 PLC 设备的连接，通过 Lambda 表达式将每个连接操作传递给 ExecuteWithExceptionHandling 进行处理。
    public void OpenAllPLC()
    {
        //依次连接所有PLC
        //ExecuteWithExceptionOpen(() => PLC.agv.Open(), "AGV");
        ExecuteWithExceptionOpen(() => PLC.storage.Open(), "Storage");
        //ExecuteWithExceptionOpen(() => PLC.manufacture.Open(), "Manufacture");
        //ExecuteWithExceptionOpen(() => PLC.detection.Open(), "Detection");
        //ExecuteWithExceptionOpen(() => PLC.assembly.Open(), "Assembly");
        //ExecuteWithExceptionOpen(() => PLC.wrapping.Open(), "Wrapping");

        //无论某个 PLC 连接操作是否抛出异常，其他操作都会继续执行，不会影响到整个流程的完成。
        Debug.Log("Finally block executed.");
        PlcOpenState();
    }

    private void ExecuteWithExceptionClose(System.Action action, string plcName)
    {
        try
        {
            action();// 执行传入的操作
        }
        // 捕获异常并记录错误信息
        catch (System.Exception ex)
        {
            Debug.LogError($"Error while closing {plcName} PLC connection: " + ex.Message);
        }
    }

    public void CloseAllPLC()
    {
        //依次断开所有PLC的连接
        ExecuteWithExceptionClose(() => PLC.agv.Close(), "AGV");
        ExecuteWithExceptionClose(() => PLC.storage.Close(), "Storage");
        ExecuteWithExceptionClose(() => PLC.manufacture.Close(), "Manufacture");
        ExecuteWithExceptionClose(() => PLC.detection.Close(), "Detection");
        ExecuteWithExceptionClose(() => PLC.assembly.Close(), "Assembly");
        ExecuteWithExceptionClose(() => PLC.wrapping.Close(), "Wrapping");

        //无论某个 PLC 连接操作是否抛出异常，其他操作都会继续执行，不会影响到整个流程的完成。
        Debug.Log("Finally block executed.");
        PlcOpenState();
    }

    private void PlcOpenState()
    {
        //初始文本
        string state = "";

        //判断，如果AGV连接成功，则输出文本。"\n"为换行修饰符
        if (PLC.agv.IsConnected)
        {
            state += "AGV已连接！\n";
        }
        else
        {
            state += "AGV已断开！\n";
        }

        if (PLC.storage.IsConnected)
        {
            state += "智能仓储单元已连接！\n";
        }
        else
        {
            state += "智能仓储单元已断开！\n";
        }

        if (PLC.manufacture.IsConnected)
        {
            state += "智能加工单元已连接！\n";
        }
        else
        {
            state += "智能加工单元已断开！\n";
        }

        if (PLC.detection.IsConnected)
        {
            state += "智能检测单元已连接！\n";
        }
        else
        {
            state += "智能检测单元已断开！\n";
        }

        if (PLC.assembly.IsConnected)
        {
            state += "智能装配单元已连接！\n";
        }
        else
        {
            state += "智能装配单元已断开！\n";
        }

        if (PLC.wrapping.IsConnected)
        {
            state += "智能包装单元已连接！\n";
        }
        else
        {
            state += "智能包装单元已断开！\n";
        }

        connectStateText.text = state;//将状态赋值给文本
        connectStateText.gameObject.SetActive(true); // 显示文本
        StartCoroutine(HideTextAfterSeconds(10)); // 启动协程
    }

    private IEnumerator HideTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        connectStateText.gameObject.SetActive(false); // 隐藏文本
    }
}

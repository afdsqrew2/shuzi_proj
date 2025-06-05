using S7.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLC : MonoBehaviour
{
    //实例化各单元PLC
    //AGV
    public static Plc agv = new Plc(CpuType.S71200, "192.168.31.2", 0, 0);
    //智能仓储单元
    public static Plc storage = new Plc(CpuType.S71200, "192.168.31.3", 0, 0);
    //智能加工单元
    public static Plc manufacture = new Plc(CpuType.S71200, "192.168.31.4", 0, 0);
    //智能检测单元
    public static Plc detection = new Plc(CpuType.S71200, "192.168.31.5", 0, 0);
    //智能装配单元
    public static Plc assembly = new Plc(CpuType.S71200, "192.168.31.6", 0, 0);
    //智能包装单元
    public static Plc wrapping = new Plc(CpuType.S71200, "192.168.31.8", 0, 0);
}

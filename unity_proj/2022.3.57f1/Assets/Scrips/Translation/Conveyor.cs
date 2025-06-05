using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [Header("速度")]
    public float speed;

    private int currDir = -1;
    private Transform[] beltsTrans;
    private BoxCollider[] beltsCollis;
    private Rigidbody[] beltsRbs;
    private Vector3 forwardRunBehindPos;
    private Vector3 behindPos;
    private float length;
    private float length2;

    protected bool init = false;

    protected void Awake()
    {
        beltsTrans = new Transform[2];
        beltsCollis = new BoxCollider[2];
        beltsRbs = new Rigidbody[2];

        // 实例化新传送带
        beltsTrans[0] = transform.Find("传送带");
        beltsTrans[1] = Instantiate(beltsTrans[0].gameObject, transform).transform;

        // 获取组件
        for (int i = 0; i < beltsTrans.Length; i++)
        {
            beltsCollis[i] = beltsTrans[i].GetComponent<BoxCollider>();
            beltsRbs[i] = beltsTrans[i].GetComponent<Rigidbody>();
        }

        // 计算长度
        length = beltsCollis[0].size.x * beltsTrans[0].localScale.x * transform.localScale.x;
        length2 = length * 2;

        // 偏移第二个传送带
        beltsTrans[1].position = beltsTrans[1].position - beltsTrans[1].right * length;

        // 起点位置
        forwardRunBehindPos = beltsTrans[1].position;
        behindPos = forwardRunBehindPos;

        init = true;
    }

    protected void FixedUpdate()
    {
        if (!init) return;

        Move();
    }

    float dis;
    public void Move()
    {
        for (int i = 0; i < beltsTrans.Length; i++)
        {
            // 移动
            beltsRbs[i].MovePosition(beltsTrans[i].position + beltsTrans[i].right * speed * currDir * Time.fixedDeltaTime);

            // 计算距离起始点距离
            dis = Vector3.Distance(beltsTrans[i].position, behindPos);

            // Collider 中心点
            beltsCollis[i].center = new Vector3(Mathf.Lerp(0.5f * currDir, -0.5f * currDir, (dis / length2)), 0, 0);

            // Collider 缩放
            if (dis <= length)
            {
                beltsCollis[i].size = new Vector3(Mathf.Lerp(0, 1, (dis / length)), 1, 1);
            }
            else if (dis > length && dis < length2)
            {
                beltsCollis[i].size = new Vector3(Mathf.Lerp(1, 0, ((dis - length) / length)), 1, 1);
            }
            // 返回起点
            else if (dis >= length2)
            {
                beltsTrans[i].position = behindPos;
            }
        }
    }
}

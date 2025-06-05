using UnityEngine;
using UnityEngine.EventSystems;

public class ModelClickHandler : MonoBehaviour
{
    public GameObject detail;
    private bool isModelVisible = false; // 详情看板当前显示状态

    //程序初始化
    private void Start()
    {
        detail.SetActive(isModelVisible);//设置看板为默认隐藏
    }

    // 事件处理方法
    private void OnModelClick()
    {
        Debug.Log("Model clicked: " + gameObject.name);

        // 在这里添加你希望在点击模型时触发的逻辑
        // 确保模型和按钮已被指定
        if (detail == null)
        {
            Debug.LogError("Model is not assigned!");
            return;
        }
        //单击后将看板设置为显示或隐藏
        isModelVisible = !isModelVisible;
        detail.SetActive(isModelVisible);
    }

    private void Update()
    {
        // 检测鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            // 进行UI射线检测
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return; // 如果点击的是UI元素，则直接返回
            }
            // 从鼠标位置发出射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 检测射线是否碰撞到物体
            if (Physics.Raycast(ray, out hit))
            {
                // 判断是否点击到了当前物体
                if (hit.collider.gameObject == gameObject)
                {
                    // 调用事件处理方法
                    OnModelClick();
                }
            }
        }
    }
}
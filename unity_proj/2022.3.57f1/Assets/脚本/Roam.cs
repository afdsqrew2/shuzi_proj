using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roam : MonoBehaviour
{
    // 定义相机灵敏度
    public float sensitivity;
    // 定义相机移动速度
    public float moveSpeed;
    // 定义角色控制器组件
    private CharacterController controller;
    public GameObject roamCam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(roamCam.activeSelf == false)
        {
            move();
        }
 
    }

    public void move()
    {
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X") * sensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
                Vector3 rotation = transform.localRotation.eulerAngles;
                rotation.x -= mouseY;
                rotation.y += mouseX;
                transform.localRotation = Quaternion.Euler(rotation);
            }
            // 获取玩家输入的前后左右移动值
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // 根据玩家输入的前后左右移动值和速度参数计算相机的移动速度
            Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
            moveDirection = moveDirection.normalized * moveSpeed;

            // 将相机的移动速度转换为全局坐标系的移动向量
            moveDirection = controller.transform.TransformDirection(moveDirection);

            // 将相机的移动向量应用到角色控制器组件上
            controller.Move(moveDirection * Time.deltaTime);
        }
    }


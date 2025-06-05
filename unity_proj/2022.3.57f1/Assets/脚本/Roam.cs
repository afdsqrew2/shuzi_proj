using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roam : MonoBehaviour
{
    // �������������
    public float sensitivity;
    // ��������ƶ��ٶ�
    public float moveSpeed;
    // �����ɫ���������
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
            // ��ȡ��������ǰ�������ƶ�ֵ
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // ������������ǰ�������ƶ�ֵ���ٶȲ�������������ƶ��ٶ�
            Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
            moveDirection = moveDirection.normalized * moveSpeed;

            // ��������ƶ��ٶ�ת��Ϊȫ������ϵ���ƶ�����
            moveDirection = controller.transform.TransformDirection(moveDirection);

            // ��������ƶ�����Ӧ�õ���ɫ�����������
            controller.Move(moveDirection * Time.deltaTime);
        }
    }


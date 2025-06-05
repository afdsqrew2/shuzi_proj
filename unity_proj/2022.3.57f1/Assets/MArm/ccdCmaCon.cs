using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ccdCmaCon : MonoBehaviour
{
    [SerializeField]
    CCDCon arm;


    RaycastHit hitInfo;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) { //�������

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo)) {

                if (!arm.IsCatch&&hitInfo.collider.CompareTag("obj")) //��ȡ����
                    arm.ccdgo(hitInfo.collider.GetComponent<catchObj>().CatchCenterPoint, hitInfo.collider.GetComponent<catchObj>());
                else //��������
                    arm.ccdgo(hitInfo.point, null);
            }

        }
    }
}

using UnityEngine;
public class Chuansong : MonoBehaviour
{
    public Vector3 direction = Vector3.right;//传送方向
    public float movespeed = 1f;//传送速度
    private Rigidbody _rig;
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 pos = _rig.position;
        Vector3 temp = -direction.normalized * movespeed * Time.fixedDeltaTime;//实际移动方向与direction相反这里取反
        _rig.position += temp;
        _rig.MovePosition(pos);
    }
}

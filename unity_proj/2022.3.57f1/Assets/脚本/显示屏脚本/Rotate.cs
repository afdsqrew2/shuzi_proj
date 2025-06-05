using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = this.transform.localEulerAngles;
        angles.z -= 360 * Time.deltaTime * speed;
        gameObject.transform.localEulerAngles = angles;
    }
}

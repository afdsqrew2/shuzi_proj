using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text3 : MonoBehaviour
{
    public Text textone;
    private float timego;
    public float max;
    public float min;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        timego = Random.Range(min, max);
        textone.text = timego.ToString(format: "0.00");
    }
}

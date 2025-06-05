using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text1 : MonoBehaviour
{
    public Text textone;
    public float timego;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timego += Time.deltaTime * speed;
        textone.text = timego.ToString(format:"0");
    }
}

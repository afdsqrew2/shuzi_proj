using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ringfill : MonoBehaviour
{
    public Image image;
    public float time;
    public float speed;
    private float retime;

    // Start is called before the first frame update
    void Start()
    {
        retime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        retime += Time.deltaTime * speed;
        image.fillAmount = retime / time;
        if(retime >= time)
        {
            retime = 0;
        }
        
    }
}

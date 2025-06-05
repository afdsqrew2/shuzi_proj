using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnChart2 : MonoBehaviour
{
    public Image image;
    public float time;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * speed;
        if(time>=0)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(1,time,1);
        }
        else
        {
            time = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableButCC : MonoBehaviour
{
    public GameObject disableButton1;
    public GameObject disableButton2;
    public GameObject disableButton3;
    public GameObject disableButton4;

    // Start is called before the first frame update
    void Start()
    {
        disableButton1.SetActive(true);
        disableButton2.SetActive(false);
        disableButton3.SetActive(false);
        disableButton4.SetActive(false);
    }

    void update()
    {
        if (disableButton1.active = true)
        {
            disableButton2.SetActive(false);
            disableButton3.SetActive(false);
            disableButton4.SetActive(false);
        }

        if (disableButton2.active = true)
        {
            disableButton1.SetActive(false);
            disableButton3.SetActive(false);
            disableButton4.SetActive(false);
        }

        if (disableButton3.active = true)
        {
            disableButton2.SetActive(false);
            disableButton1.SetActive(false);
            disableButton4.SetActive(false);
        }

        if (disableButton4.active = true)
        {
            disableButton2.SetActive(false);
            disableButton3.SetActive(false);
            disableButton1.SetActive(false);
        }

    }

    public void setBut1()
    {
        disableButton1.SetActive(true);
        disableButton2.SetActive(false);
        disableButton3.SetActive(false);
        disableButton4.SetActive(false);
    }

    public void setBut4()
    {
        disableButton4.SetActive(true);
        disableButton2.SetActive(false);
        disableButton3.SetActive(false);
        disableButton1.SetActive(false);
    }

    public void setBut2()
    {
        disableButton2.SetActive(true);
        disableButton1.SetActive(false);
        disableButton3.SetActive(false);
        disableButton4.SetActive(false);
    }

    public void setBut3()
    {
        disableButton3.SetActive(true);
        disableButton2.SetActive(false);
        disableButton1.SetActive(false);
        disableButton4.SetActive(false);
    }

}

    
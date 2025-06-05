using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipbutton : MonoBehaviour
{
    public GameObject disableButton;
    public GameObject selectButton;

    void Start()
    {
        disableButton.SetActive(true);
        selectButton.SetActive(false);
    }

    public void changedisButton()
    {
        disableButton.SetActive(false);
        selectButton.SetActive(true);
    }
    public void changeselectButton()
    {
        disableButton.SetActive(true);
        selectButton.SetActive(false);
    }





}

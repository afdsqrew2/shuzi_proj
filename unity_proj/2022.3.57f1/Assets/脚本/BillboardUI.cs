using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    public GameObject _mainCamera;
    public GameObject _roamCamera;
    public GameObject _Camera01;
    public GameObject _Camera02;
    public GameObject _Camera1;
    public GameObject _Camera2;
    public GameObject _Camera3;
    public GameObject _Camera4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_mainCamera.activeSelf == true)
        {
            transform.rotation = _mainCamera.transform.rotation;
        }

        if (_roamCamera.activeSelf == true)
        {
            transform.rotation = _roamCamera.transform.rotation;
        }

        if (_Camera01.activeSelf == true)
        {
            transform.rotation = _Camera01.transform.rotation;
        }

        if (_Camera02.activeSelf == true)
        {
            transform.rotation = _Camera02.transform.rotation;
        }

        if (_Camera1.activeSelf == true)
        {
            transform.rotation = _Camera1.transform.rotation;
        }

        if (_Camera2.activeSelf == true)
        {
            transform.rotation = _Camera2.transform.rotation;
        }

        if (_Camera3.activeSelf == true)
        {
            transform.rotation = _Camera3.transform.rotation;
        }

        if (_Camera4.activeSelf == true)
        {
            transform.rotation = _Camera4.transform.rotation;
        }
    }
}

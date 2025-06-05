using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigationCanvasCC : MonoBehaviour
{
    public GameObject informOne;
    public GameObject informTwo;
    public GameObject informThree;
    public GameObject informFour;


    // Start is called before the first frame update
    void Start()
    {
        informOne.SetActive(true);
        informTwo.SetActive(false);
        informThree.SetActive(false);
        informFour.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SOHinformOne()
    {
        informOne.SetActive(!informOne.activeSelf);
        informTwo.SetActive(false);
        informThree.SetActive(false);
        informFour.SetActive(false);
    }

    public void SOHinformTwo()
    {
        informOne.SetActive(false);
        informTwo.SetActive(!informTwo.activeSelf);
        informThree.SetActive(false);
        informFour.SetActive(false);
    }

    public void SOHinformThree()
    {
        informOne.SetActive(false);
        informTwo.SetActive(false);
        informThree.SetActive(!informTwo.activeSelf);
        informFour.SetActive(false);

    }

    public void SOHinformFour()
    {
        informOne.SetActive(false);
        informTwo.SetActive(false);
        informThree.SetActive(false);
        informFour.SetActive(!informFour.activeSelf);
    }


}

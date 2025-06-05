using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEvents : MonoBehaviour
{
    public Animator discharge;
    public Animator station1;
    public Animator station2;
    public Animator station3;
    public Animator station4;
    public Animator AGV;
    // Start is called before the first frame update



    public void ALLZERO()
    {
        discharge.speed = 0;
        station1.speed = 0;
        station2.speed = 0;
        station3.speed = 0;
        station4.speed = 0;
        AGV.speed = 0;
        //discharge.SetBool("out", false);
        //discharge.SetBool("enter", false);
        //station1.SetBool("one", false);
        //station2.SetBool("two", false);
        //station3.SetBool("three", false);
        //station4.SetBool("four", false);
        //AGV.SetBool("two", false);
        //AGV.SetBool("four", false);
    }


}

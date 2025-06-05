using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator AGV;
    Animator Storage;
    Animator Manufacture;
    Animator Detection;
    Animator Assembly;
    Animator Wrapping;


    public void EnableAnimator()
    {
        if (AGV != null)
        {
            AGV.enabled = true;
        }

        if (Storage != null)
        {
            Storage.enabled = true;
        }

        if (Manufacture != null)
        {
            Manufacture.enabled = true;
        }

        if (Detection != null)
        {
            Detection.enabled = true;
        }

        if (Assembly != null)
        {
            Assembly.enabled = true;
        }

        if (Wrapping != null)
        {
            Wrapping.enabled = true;
        }

        Debug.Log("Animation Enabled");
    }

    public void DisableAnimator()
    {
        if (AGV != null)
        {
            AGV.enabled = false;
        }

        if (Storage != null)
        {
            Storage.enabled = false;
        }

        if (Manufacture != null)
        {
            Manufacture.enabled = false;
        }

        if (Detection != null)
        {
            Detection.enabled = false;
        }

        if (Assembly != null)
        {
            Assembly.enabled = false;
        }

        if (Wrapping != null)
        {
            Wrapping.enabled = false;
        }

        Debug.Log("Animation Disabled");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{

    public void OnMouseEnter()
    {
        Debug.Log("enter");
        transform.localScale += new Vector3(2.1F, 2.1f, 1.1f); //adjust these values as you see fit
    }


    public void OnMouseExit()
    {
        Debug.Log("left");
        transform.localScale = new Vector3(1, 1, 1);  // assuming you want it to return to its original size when your mouse leaves it.
    }

}
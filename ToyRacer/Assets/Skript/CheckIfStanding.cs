using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfStanding : MonoBehaviour
{
    public bool state = true;
    public string tagOfOtherObject = "";

    //checks if the collider hits a object with the tag "x". 
    // in another script, this gives the car the "lying down controlls"
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(tagOfOtherObject))
        {
            state = true;
        }

    }
    //makes "state" false if the box collider is not hiting a object tagged "x". 
    // player is now able to more normally 
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag(tagOfOtherObject))
        {
            state = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

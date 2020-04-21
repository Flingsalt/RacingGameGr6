using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfHasFallen : MonoBehaviour
{

    public bool state = false;
    public string tagOfOtherObject = "";

    //checks if the collider hits a object with the tag "x". 
    //In the Transform Function Script, if state is "true" this makes our car not being able to more forward and gives it different controlles. 
    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.CompareTag(tagOfOtherObject))
        {
            state = true;
        }

    }

    //makes "state" false if the box collider is not hiting a object tagged "x". 
    //Car can now move as usual
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

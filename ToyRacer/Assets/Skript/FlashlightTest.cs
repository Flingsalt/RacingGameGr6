using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlashlightTest : MonoBehaviour
{
    public GameObject flashLight;
    Light lightComp;

    // Start is called before the first frame update
    void Start()
    {
        lightComp = flashLight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightComp.enabled = !lightComp.enabled;
        }
    }
}

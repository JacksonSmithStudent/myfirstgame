using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Light light;
     void Start()
    {
        light = GetComponent<Light>();

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            light.enabled = !light.enabled;
        }
    }
}

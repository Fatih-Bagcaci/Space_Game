using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTrail : MonoBehaviour
{
    //public KeyCode RightKey = KeyCode.RightArrow;
    //public KeyCode DKey = KeyCode.RightArrow;
    TrailRenderer Trail;
    

    void Start()
    {
        Trail = gameObject.GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D) == true)
        {
            Trail.enabled = true;
        }
        else{
            Trail.enabled = false;
        }
    }
}

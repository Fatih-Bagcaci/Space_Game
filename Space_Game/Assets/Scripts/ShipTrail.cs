using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTrail : MonoBehaviour
{
    TrailRenderer Trail;
   
    void Start()
    {
        Trail = gameObject.GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Trail.enabled = true;
        }
        else{
            Trail.enabled = false;
        }
    }
}

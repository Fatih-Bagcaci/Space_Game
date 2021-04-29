using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTrail : MonoBehaviour
{
    TrailRenderer shipTrail;
    LineRenderer shipLine;
   
    void Start()
    {
        if (gameObject.GetComponent<TrailRenderer>() != null) {
            shipTrail = gameObject.GetComponent<TrailRenderer>();
        }
        if (gameObject.GetComponent<LineRenderer>() != null)
        {
            shipLine = gameObject.GetComponent<LineRenderer>();
        }
    }

    void Update()
    {
        if (gameObject.GetComponent<TrailRenderer>() != null)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                shipTrail.enabled = true;
            }
            else
            {
                shipTrail.enabled = false;
            }
        }

        if (gameObject.GetComponent<LineRenderer>() != null)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                shipLine.enabled = false;
            }
            else
            {
                shipLine.enabled = true;
            }
        }
    }
}

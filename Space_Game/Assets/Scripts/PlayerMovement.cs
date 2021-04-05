using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovement;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // Ship movement
        horizontalMovement = Input.GetAxis("Horizontal") * 20;
        verticalMovement = Input.GetAxis("Vertical") * 20;
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalMovement, verticalMovement, 0);

        // Rotate Ship slightly when moving up / down, doesn't work
        /*if ((verticalMovement > 0) || (verticalMovement < 0))
        {
            float tiltAroundX = Input.GetAxis("Horizontal") * tiltAngle;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        else if(verticalMovement == 0)
        {
            transform.Rotate(0, 0, 0, Space.Self);
        }*/
    }
}

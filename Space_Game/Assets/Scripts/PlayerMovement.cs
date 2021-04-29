using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    float tiltAngle = 80f;

    Vector3 CurrentEuler;

    void Update()
    {
        Rigidbody m_Rigidbody;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Ship movement if both right and left keys are pressed
        if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.LeftArrow) == true)
        {
            horizontalMovement = 0;
        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
        }
        // Ship movement if both up and down keys are pressed
        if (Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == true)
        {
            verticalMovement = 0;
        }
        else
        {
            verticalMovement = Input.GetAxisRaw("Vertical");
        }

        Vector3 Direction = new Vector3(verticalMovement, horizontalMovement, 0) * Time.deltaTime * 15;
        transform.Translate(Direction);

        //Z remains the same
        transform.position = new Vector3(transform.position.x, transform.position.y, 276);


        //Ship Rotation
        float tiltAroundX = tiltAngle * Time.deltaTime;
        bool clickUp = Input.GetKey(KeyCode.UpArrow);
        bool clickDown = Input.GetKey(KeyCode.DownArrow);
        float playersXRotationAngle = transform.localRotation.eulerAngles.x;

        if (clickDown == clickUp)
        {
            transform.rotation = Quaternion.Euler(0, 180, 90);
        }
        else if (clickUp == true && (((playersXRotationAngle <= 360) && (playersXRotationAngle >= 330)) || playersXRotationAngle == 0)) {
            transform.Rotate(0, tiltAroundX, 0, Space.Self);
        }
        else if (clickDown == true && ((playersXRotationAngle >= 0) && (playersXRotationAngle <= 30)))
        {
            transform.Rotate(0, -tiltAroundX, 0, Space.Self);
        }
    }
}

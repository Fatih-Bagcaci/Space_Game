using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    float tiltAngle = 80f;
    private float playerSpeed = 3.75f;

    Vector3 CurrentEuler;

    void Update()
    {
        Rigidbody m_Rigidbody;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        //Debug.Log(transform.position.z);


        // Ship movement if both right and left keys are pressed, or if the x position is within a certain limit
        if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.LeftArrow) == true)
        {
            horizontalMovement = 0;
        }else if (transform.position.x > -20.4 && Input.GetKey(KeyCode.LeftArrow) == false)
        {
            horizontalMovement = 0;
        }else if (transform.position.x < -34 && Input.GetKey(KeyCode.RightArrow) == false)
        {
            horizontalMovement = 0;
        }else
        {
            horizontalMovement = -Input.GetAxisRaw("Horizontal");
        }
        // Ship movement if both up and down keys are pressed
        if (Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == true)
        {
            verticalMovement = 0;
        }else if (transform.position.y > 136.4 && Input.GetKey(KeyCode.DownArrow) == false)
        {
            verticalMovement = 0;
        }else if (transform.position.y < 128.8 && Input.GetKey(KeyCode.UpArrow) == false)
        {
            verticalMovement = 0;
        }else
        {
            verticalMovement = Input.GetAxisRaw("Vertical");
        }

        Vector3 Direction = new Vector3(horizontalMovement, verticalMovement, 0) * Time.deltaTime * playerSpeed;
        transform.Translate(Direction);

        //Z remains the same
        transform.position = new Vector3(transform.position.x, transform.position.y, 276);

        //Ship Rotation
        float tiltAroundX = tiltAngle * Time.deltaTime * 0.1f;
        bool clickUp = Input.GetKey(KeyCode.UpArrow);
        bool clickDown = Input.GetKey(KeyCode.DownArrow);
        float playersXRotationAngle = transform.localRotation.eulerAngles.x;

        if (clickDown == clickUp)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (clickUp == true && ((playersXRotationAngle <= 360) && (playersXRotationAngle >= 340)) || playersXRotationAngle == 0)
        {
            transform.Rotate(-tiltAroundX, 0, 0, Space.Self);
        }
        else if (clickDown == true && ((playersXRotationAngle >= 0) && (playersXRotationAngle <= 20)))
        {
            transform.Rotate(tiltAroundX, 0, 0, Space.Self);
        }
        else if (clickUp == false && ((playersXRotationAngle <= 360) && (playersXRotationAngle >= 340)))
        {
            transform.Rotate(tiltAroundX, 0, 0, Space.Self);
        }
        else if (clickDown == false && ((playersXRotationAngle >= 0) && (playersXRotationAngle <= 20)))
        {
            transform.Rotate(-tiltAroundX, 0, 0, Space.Self);
        }
    }
}

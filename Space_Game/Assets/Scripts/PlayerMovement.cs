using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    float speed = 10;
    float smooth = 5.0f;
    float tiltAngle = 30f;

    void Update()
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Ship movement if both right and left keys are pressed
        if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.LeftArrow) == true) {
            horizontalMovement = 0;
        }
        else{
            horizontalMovement = Input.GetAxisRaw("Horizontal");
        }
        // Ship movement if both up and down keys are pressed
        if (Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == true){
            verticalMovement = 0;
        }
        else{
            verticalMovement = Input.GetAxisRaw("Vertical");
        }

        Vector3 Direction = new Vector3(verticalMovement, horizontalMovement, 0) * Time.deltaTime * 15;
        transform.Translate(Direction);

        //Ship Rotation
        /*
        float tiltAroundX = tiltAngle * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow) == true && ((transform.eulerAngles.x <= 1) || (transform.eulerAngles.x >= -30))){
            transform.Rotate(0, tiltAroundX, 0);
        }else if (Input.GetKey(KeyCode.DownArrow) == true && ((transform.eulerAngles.x >= 1) || (transform.eulerAngles.x <= 30)))
        {
            transform.Rotate(0, -tiltAroundX, 0);
        }*/
    }
}

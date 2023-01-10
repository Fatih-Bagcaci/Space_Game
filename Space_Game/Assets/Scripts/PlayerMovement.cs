using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    float tiltAngle = 80f;
    private float playerSpeed = 3.75f;
    bool rightMove;
    bool leftMove;
    bool upMove;
    bool downMove;
    public GameObject healthBar;
    public GameObject overheatBar;
    public GameObject scoreText;

    Vector3 CurrentEuler;

    void Update()
    {
        rightMove = Input.GetKey(KeyCode.RightArrow);
        leftMove = Input.GetKey(KeyCode.LeftArrow);
        upMove = Input.GetKey(KeyCode.UpArrow);
        downMove = Input.GetKey(KeyCode.DownArrow);

        Rigidbody m_Rigidbody;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        // Ship movement if both right and left keys are pressed, or if the x position is within a certain limit
        if (rightMove && leftMove)
        {
            horizontalMovement = 0;
        }
        else if (transform.position.x > -20.4 && !leftMove)
        {
            horizontalMovement = 0;
        }
        else if (transform.position.x < -34 && !rightMove)
        {
            horizontalMovement = 0;
        }
        else
        {
            horizontalMovement = -Input.GetAxisRaw("Horizontal");
        }
        // Ship movement if both up and down keys are pressed
        if (upMove && downMove)
        {
            verticalMovement = 0;
        }
        else if (transform.position.y > 136.4 && !downMove)
        {
            verticalMovement = 0;
        }
        else if (transform.position.y < 128.8 && !upMove)
        {
            verticalMovement = 0;
        }
        else
        {
            verticalMovement = Input.GetAxisRaw("Vertical");
        }

        //Keeping the ship's Z the same
        transform.position = new Vector3(transform.position.x, transform.position.y, 276);

        //Ship Slight Rotation
        float tiltAroundX = tiltAngle * Time.deltaTime * 0.1f;
        float playersXRotationAngle = transform.localRotation.eulerAngles.x;

        if (downMove == upMove)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (upMove == true && ((playersXRotationAngle <= 360) && (playersXRotationAngle >= 340)) || playersXRotationAngle == 0)
        {
            transform.Rotate(-tiltAroundX, 0, 0, Space.Self);
        }
        else if (downMove == true && ((playersXRotationAngle >= 0) && (playersXRotationAngle <= 20)))
        {
            transform.Rotate(tiltAroundX, 0, 0, Space.Self);
        }
        else if (upMove == false && ((playersXRotationAngle <= 360) && (playersXRotationAngle >= 340)))
        {
            transform.Rotate(tiltAroundX, 0, 0, Space.Self);
        }
        else if (downMove == false && ((playersXRotationAngle >= 0) && (playersXRotationAngle <= 20)))
        {
            transform.Rotate(-tiltAroundX, 0, 0, Space.Self);
        }

        //Reduce HUD transparency
        if (transform.position.y < 129.5 && transform.position.x < -29.95)
        {
            healthBar.GetComponent<CanvasGroup>().alpha = 0.25f;
            overheatBar.GetComponent<CanvasGroup>().alpha = 0.25f;
        }
        else if (transform.position.y > 129.5 || transform.position.x > -29.95)
        {
            healthBar.GetComponent<CanvasGroup>().alpha = 1f;
            overheatBar.GetComponent<CanvasGroup>().alpha = 1f;
        }

        if (transform.position.y > 135.68 && transform.position.x < -32.64)
        {
            scoreText.GetComponent<CanvasGroup>().alpha = 0.25f;
        }
        else if (transform.position.y < 135.68 || transform.position.x > -32.64)
        {
            scoreText.GetComponent<CanvasGroup>().alpha = 1f;
        }

        //Implement Movement
        Vector3 Direction = new Vector3(horizontalMovement, verticalMovement, 0) * Time.deltaTime * playerSpeed;
        transform.Translate(Direction);
    }
}

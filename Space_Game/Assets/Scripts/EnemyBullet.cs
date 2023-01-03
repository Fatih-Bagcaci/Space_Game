using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody enemyProjectile;
    public Transform enemyShipFrontEnd;


    void Update()
    {
        //If you click "X", the bullet will have a force in the -ve x direction
        if (Input.GetKeyDown("x"))
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
            projectileInstance.AddForce(-200f, 0, 0);
        }
    }
}

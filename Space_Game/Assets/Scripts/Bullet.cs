using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform ShipFrontEnd;

    void Update()
    {
        //If you click "Z", the bullet will have a force in the +ve x direction
        if (Input.GetKeyDown("z"))
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, ShipFrontEnd.position, ShipFrontEnd.rotation);
            projectileInstance.AddForce(1000f,0,0);
        }
    }
}

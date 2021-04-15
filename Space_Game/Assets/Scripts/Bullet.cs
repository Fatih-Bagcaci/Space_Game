using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform barrelEnd;

    void Update()
    {
        //If you click "Z", the bullet will have a force in the +ve x direction
        if (Input.GetKeyDown("z"))
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
            projectileInstance.AddForce(2000f,0,0);
        }
    }
}

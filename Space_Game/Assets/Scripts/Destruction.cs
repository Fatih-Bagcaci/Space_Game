using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    //Bullet destroyed after x seconds
    void Start()
    {
        if (gameObject.tag == "projectile") {
            Destroy(gameObject, 3f);
        }
    }

    //Bullet destroyed on impact
    private void OnCollisionEnter(Collision col)
    {
        var tagName = col.gameObject.tag;

        if (tagName == "spaceship" || tagName == "projectile" || gameObject.tag == "projectile")
        {
            Destroy(gameObject);
        }
    }
    

}

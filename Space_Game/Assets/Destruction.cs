using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    //Bullet destroyed after x seconds
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    //Bullet destroyed on impact
    private void OnCollisionEnter(Collision col)
    {
        var tagName = col.gameObject.tag;

        if (tagName == "spaceship")
        {
            Destroy(gameObject);
        }
        if (tagName == "projectile")
        {
            Destroy(gameObject);
        }
    }
    

}

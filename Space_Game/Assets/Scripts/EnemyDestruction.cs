using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(transform.position.x < -34)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
        var tagName = col.gameObject.tag;

        if (tagName == "spaceship" || tagName == "projectile" || gameObject.tag == "projectile")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    private int healthMax = 3;
    private bool invincibility = false;
    public float invincibleTimeStart = 5;
    public float invincibleTime;

    private void Start()
    {
        health = healthMax;
    }

    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            spaceshipHeal(3);
        }

        //if the player is temporarily invincible or not
        if (invincibleTime > 0 && invincibility == true)
        {
            invincibleTime -= Time.deltaTime;
        }
        else
        {
            invincibility = false;
            invincibleTime = invincibleTimeStart;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "projectile" && health > 0 && invincibility == false)
        {
            receiveSpaceshipDamage(1);
        }
    }
 
    public int getHealth()
    {
        return health;
    }

    private void receiveSpaceshipDamage(int damageAmount)
    {
        health -= damageAmount;
        invincibility = true;
        
        Debug.Log("Health Remaining: " + health + "/3");
        
        if (health == 0)
        {
            Debug.Log("Health = 0");
        }
    }
    private void spaceshipHeal(int healAmount)
    {
        health += healAmount;
        if (health >= healthMax)
        {
            health = healthMax;
        }
    }

}

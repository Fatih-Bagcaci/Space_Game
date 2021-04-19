using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    private int healthMax = 3;
    public Rigidbody projectile;
    public Rigidbody player;

    private void Update()
    {
        //Debug.Log("Damage" + health);
    }

    /*public void healthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }*/
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bullet(Clone)" && health > 0)
        {
            Damage(1);
        }
    }
 
    public int getHealth()
    {
        return health;
    }
    
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Damage" + health);
        if (health == 0)
        {
            Debug.Log("Health = 0");
        }
    }
    /*public void Heal(int healAmount)
    {
        healAmount = 1;
        health += healAmount;
        if (health >= healthMax)
        {
            health = healthMax;
        }
    }*/

}

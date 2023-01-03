using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    private float enemyHorMovement;
    private float enemyVerMovement=0;
    private float enemySpeed = 1f;
    private float movementCooldownY = 0f;
    private float movementCooldownX = 0f;
    public Rigidbody projectile;
    public GameObject enemyShip;
    public Transform EnemyFrontEnd;
    private float shootingInterval;
    private float shootingTime = 5f;

    Vector3 CurrentEuler;
    private void Start()
    {
    }
    private void Update()
    {
        //X movement for enemies
        if (transform.position.x > -27.75)
        {
            enemyHorMovement = Random.Range(-0.1f, -1f);
        }
        else if (transform.position.x < -27.75)
        {
            enemyHorMovement = 0;
        }

        //Y movement for enemies
        if (movementCooldownY>0 || movementCooldownY<2)
        {
            movementCooldownY -= Time.deltaTime;
        }
        if (transform.position.y < 136.4 && transform.position.y > 128.8 && movementCooldownY<=0)
            {
                enemyVerMovement = Random.Range(-1f, 1f);
                movementCooldownY = 2f;
            }
        else if (transform.position.y > 136.4)
            {
                enemyVerMovement = Random.Range(-0.1f, -1f);
                movementCooldownY = 2f;
            }
        else if (transform.position.y < 128.8)
            {
                enemyVerMovement = Random.Range(0.1f, 1f);
                movementCooldownY = 2f;
            }
        
        Vector3 Direction = new Vector3(enemyHorMovement, enemyVerMovement, 0) * Time.deltaTime * enemySpeed;
        transform.Translate(Direction);

        //Shooting gun every x amount of time
        if (shootingTime > 0 && enemyShip != null)
        {
            shootingTime -= Time.deltaTime;
        }
        else if (shootingTime <= 0 && enemyShip != null)
        {
            shootingInterval = Random.Range(2f, 6f);
            shootingTime = shootingInterval;
            enemyShoot();
        }
    }
    void enemyShoot()
    {
        //if () {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectile, EnemyFrontEnd.position, EnemyFrontEnd.rotation);
            projectileInstance.AddForce(-200f, 0, 0);
        //}
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("projectile"))
        {
            Score.scoreValue += 1;
        }
    }
    }

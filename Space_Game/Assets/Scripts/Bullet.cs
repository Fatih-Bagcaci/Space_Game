using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform ShipFrontEnd;
    float autoShootCounter = 0;
    float overHeatCounter = 0;
    bool zHasShot = false;
    public Slider slider;

    void Update()
    {
        Debug.Log(overHeatCounter);
        if (zHasShot == false) {
            //If you click "Z", the bullet will have a force in the +ve x direction
            if (Input.GetKeyDown("z") & Time.timeScale != 0f) {
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(projectile, ShipFrontEnd.position, ShipFrontEnd.rotation);
                projectileInstance.AddForce(700f, 0, 0);
                autoShootCounter = 0;
                overHeatCounter += 10;
            }

            if (Input.GetKey("z") & Time.timeScale != 0f) {
                autoShootCounter += 1f;
                if (autoShootCounter > 150) {
                    Rigidbody projectileInstance;
                    projectileInstance = Instantiate(projectile, ShipFrontEnd.position, ShipFrontEnd.rotation);
                    projectileInstance.AddForce(700f, 0, 0);
                    autoShootCounter = 0;
                    overHeatCounter += 10;
                }
            }
        }
        if (overHeatCounter > 0 & zHasShot == false)
        {
            overHeatCounter -= 0.03f;
        }

        if (overHeatCounter > 100 & zHasShot == false)
        {
            zHasShot = true;
        }
        else if (overHeatCounter > 0 & overHeatCounter < 200 & zHasShot == true)
        {
            overHeatCounter -= 0.1f;
        }
        else if (overHeatCounter < 0 & zHasShot == true)
        {
            zHasShot = false;
            overHeatCounter = 0;
        }
        SetOverheat(overHeatCounter);
    }
    public void SetOverheat (float overheatValue)
    {
        slider.value = overheatValue;
    }
}

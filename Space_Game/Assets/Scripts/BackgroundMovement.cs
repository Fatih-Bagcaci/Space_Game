using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject backgroundImage;
    public Transform backgroundSpawnPoint;
    public GameObject backgroundCopy;
    private bool isBackgroundThere = false;
    private float timeCounter = 0;

    void Update()
    {
        //Moves CanvasBackground to the side
        transform.Translate(-1f* Time.deltaTime, 0,0);

        if (transform.localPosition.x < -990 && isBackgroundThere == false)
        {
            isBackgroundThere = true;
            backgroundCopy = Instantiate(backgroundImage, backgroundSpawnPoint.position, backgroundSpawnPoint.rotation);
            backgroundCopy.transform.Translate(-1f * Time.deltaTime, 0, 0);
            timeCounter = 0;
        }
        timeCounter += Time.deltaTime;
        Debug.Log(timeCounter);

        if (transform.localPosition.x < -1021)
        {
            transform.localPosition = new Vector3(-953f, -407.03f, 285.319f);
        }
        
        if (timeCounter > 68f)
        {
            Destroy(backgroundCopy);
            isBackgroundThere = false;
            timeCounter = 0;
        }


    }
}

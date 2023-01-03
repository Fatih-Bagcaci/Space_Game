using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource AudioSource;

    private float musicVolume = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(musicVolume);

        if (Time.timeScale == 0f)
        {
            AudioSource.volume = 0f;
        }
        else
        {
            AudioSource.volume = musicVolume;
        }
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }

}

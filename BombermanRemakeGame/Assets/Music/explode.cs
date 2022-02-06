using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{

    public AudioClip[] myClip;
    AudioSource audioData;

    public bool explosion_play_sound = false;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.clip = myClip[Random.Range(0, 2)];
    }

    // Update is called once per frame
    void Update()
    {
        if (explosion_play_sound)
        {
            audioData = GetComponent<AudioSource>();
            audioData.clip = myClip[Random.Range(0, 3)];
            Debug.Log(audioData.clip.name);
            audioData.Play();
            explosion_play_sound = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicsPlayer : MonoBehaviour
{

    public AudioClip[] myClip;
    AudioSource audioData;

    private void Awake()
    {
        GameObject [] myObjs = GameObject.FindGameObjectsWithTag("MusicsPlayerTag");
        if (myObjs.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.clip = myClip[Random.Range(0, 3)];
        audioData.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioData.isPlaying)
        {
            audioData = GetComponent<AudioSource>();
            audioData.clip = myClip[Random.Range(0, 3)];
            audioData.Play();
        }   
    }
}

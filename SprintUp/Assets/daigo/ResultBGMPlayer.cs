using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBGMPlayer : MonoBehaviour
{
    public AudioClip resultBGM;
    private AudioSource audioSorce;
    // Start is called before the first frame update
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();
        if (audioSorce != null)
        {
            audioSorce = GetComponentInParent<AudioSource>();

            audioSorce.clip = resultBGM;
            audioSorce.loop = true;
            audioSorce.playOnAwake = false;

            audioSorce.Play();
        }
    }

        

    // Update is called once per frame
    void Update()
    {
        
    }
}

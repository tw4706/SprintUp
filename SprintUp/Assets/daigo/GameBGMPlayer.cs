using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGMPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgmclip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmclip;
        audioSource.Play();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

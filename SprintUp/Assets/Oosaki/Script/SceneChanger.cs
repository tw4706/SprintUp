using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneChanger : MonoBehaviour
{
    public FadeManager fadeManager;
    AudioSource audioSource;
    public AudioClip PressButtonSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeScene(string sceneName)
    {
        audioSource.PlayOneShot(PressButtonSound);
        fadeManager.ChangeScene(sceneName);
    }

    public void GameEnd()
    {
        audioSource.PlayOneShot(PressButtonSound);
        fadeManager.GameEnd();
    }
}

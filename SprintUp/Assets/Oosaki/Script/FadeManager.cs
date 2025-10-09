using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;
    private static FadeManager instance;
    public static FadeManager Instance => instance;

    public GameObject firstButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = new Color(0, 0, 0, 0);
            if (SceneManager.GetActiveScene().name != "GameScene")
            {
                StartCoroutine(FadeIn());
            }
        }
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        EventSystem.current.SetSelectedGameObject(null);

        float time = 0;
        while (time < fadeDuration)
        {
            float alpha = 1 - (time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0); // © C³ƒ|ƒCƒ“ƒg

        if (firstButton != null)
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        float time = 0;
        while (time < fadeDuration)
        {
            float alpha = time / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 1);

        yield return null;

        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EventSystem.current.SetSelectedGameObject(null);
        firstButton = GameObject.FindWithTag("FirstSelectable");

        if (fadeImage != null)
        {
            StartCoroutine(FadeIn());
        }
    }
}

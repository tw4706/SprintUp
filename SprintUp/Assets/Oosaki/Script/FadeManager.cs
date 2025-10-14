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
    //bool isInput_1 = false;
    //bool isInput_2 = false;

    void Start()
    {
        //isInput_1 = Input.GetKey("joystick 1");
        //isInput_2 = Input.GetKey("joystick 2");
    }

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // FadeManagerとその子（fadeImage）を永続化
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
            StartCoroutine(FadeIn());
        }

    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    // タイトルに戻る
    public void ReturnToTitle()
    {
        if (FadeManager.Instance != null && !FadeManager.Instance.gameObject.activeSelf)
        {
            FadeManager.Instance.gameObject.SetActive(true); // ← これが重要！
        }

        FadeManager.Instance.FadeToScene("TitleScene");
    }

    IEnumerator FadeIn()
    {
        // 確認用
        if (fadeImage == null)
        {
            Debug.LogError("fadeImage is missing!");
            yield break;
        }

        EventSystem.current.SetSelectedGameObject(null);

        float time = 0;
        while (time < fadeDuration)
        {
            float alpha = 1 - (time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0); // ← 修正ポイント

        fadeImage.raycastTarget = false; // UIブロック防止

        yield return new WaitForEndOfFrame(); // UI描画完了を待つ


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
        fadeImage.gameObject.SetActive(true);
        fadeImage.raycastTarget = true;

        firstButton = GameObject.FindWithTag("FirstSelectable");

        if (fadeImage != null)
        {
            StartCoroutine(FadeIn());
        }
    }
}

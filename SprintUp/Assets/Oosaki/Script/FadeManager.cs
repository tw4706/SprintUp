using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;
    bool isFadingIn = false;
    bool isFadingOut = false;
    string nextSceneName;
    bool isSceneChanged = false; // シーンが変更されたかどうかのフラグ

    void Start()
    {
        StartFadeIn(); // 最初にフェードイン（暗→明）
    }

    void Update()
    {
        if (isFadingIn)
        {
            Color color = fadeImage.color;
            color.a -= fadeSpeed * Time.deltaTime;
            fadeImage.color = color;

            if (color.a <= 0f)
            {
                color.a = 0f;
                fadeImage.color = color;
                isFadingIn = false;
            }
        }
        else if (isFadingOut)
        {
            Color color = fadeImage.color;
            color.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = color;

            if (color.a >= 1f)
            {
                color.a = 1f;
                fadeImage.color = color;
                isFadingOut = false;

                // フェードアウト完了後にシーン遷移
                if (isSceneChanged)
                {
                    SceneManager.LoadScene(nextSceneName);
                    isSceneChanged = false;
                }
            }
        }
    }

    public void StartFadeIn()
    {
        isFadingIn = true;
        isFadingOut = false;
    }

    public void StartFadeOut()
    {
        isFadingOut = true;
        isFadingIn = false;
    }

    public void ChangeScene(string sceneName)
    {
        nextSceneName = sceneName;
        isSceneChanged = true;
        StartFadeOut(); // フェードアウト開始 → 完了後にシーン遷移
    }

}

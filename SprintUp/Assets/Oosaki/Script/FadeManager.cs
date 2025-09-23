using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FadeManager : MonoBehaviour
{
    public Image fadeImage; // フェード用の変数
    public float fadeDuration = 1.0f; // フェードの間隔
    public GameObject obj;
    private static FadeManager instance;
    public string scene;

    void Start()
    {
        if(FindObjectOfType<FadeManager>()==null)
        {
            Instantiate(obj);
        }
    }

    // コルーチンとはUpdateを使わずに自然な流れで
    // 処理を行うための仕組み

    // フェードインのコルーチン
    void Awake()
    {
        // シーンが変わっても消えないようにする
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
    // フェードイン
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }
    // IEnumeratorはコルーチンを使うため特別な戻り値の型
    // 順番に何かを取り出す処理や、
    // 途中で処理を止めて再開する処理に使われる

    // フェードアウトのコルーチン
    private IEnumerator FadeIn()
    {
        float time = 0;
        while (time < fadeDuration)
        {
            float alpha = 1 - (time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    // フェードイン
    private IEnumerator FadeOut(string sceneName)
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
        SceneManager.LoadScene(sceneName);
    }
    public void OnClick()
    {
       FadeManager fade = FindObjectOfType<FadeManager>();
         if (fade != null)
         {
              fade.FadeToScene("MenuScene");
         }
         else
         {
              Debug.Log("FadeManagerが見つからない！");
         }
    }
}

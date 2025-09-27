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

    public static FadeManager Instance=> instance;

    void Start()
    {
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            FadeToScene("ResultScene"); // 任意のシーン名
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
            fadeImage.color = new Color(0, 0, 0, 1);
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


        // ここで1フレーム待つことで、最後の黒画面が描画される
        yield return null;

        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (fadeImage != null)
        {
            StartCoroutine(FadeIn());
        }
    }

}

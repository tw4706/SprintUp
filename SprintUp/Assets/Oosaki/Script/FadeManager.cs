using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FadeManager : MonoBehaviour
{
    public Image fadeImage; // フェード用の変数
    public float fadeDuration = 1.0f; // フェードの間隔
    public GameObject obj;
    private static FadeManager instance;
    public static FadeManager Instance=> instance;
    // 最初に選択するボタン
    public GameObject firstButton;

    void Start()
    {
    }

    void Update()
    {
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

    // フェードインのコルーチン
    IEnumerator FadeIn()
    {

        // 選択状態を一時的に解除
        EventSystem.current.SetSelectedGameObject(null);

        float time = 0;
        while (time < fadeDuration)
        {
            float alpha = 1 - (time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            time += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0);

        // フェード完了後にボタンを再選択
        if (firstButton != null)
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    // フェードイン
    IEnumerator FadeOut(string sceneName)
    {
        float time = 0;
        // ゲームシーンかどうか判定
        bool isGameScene = sceneName == "GameScene";
        while (time < fadeDuration)
        {
            float alpha = time / fadeDuration;
            // ゲームシーンなら透明、そうでなければ透明
            Color fadeColor = new Color(0, 0, 0, alpha);

            fadeImage.color = fadeColor;
            time += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(255, 255, 255, 255);

        // ここで1フレーム待つことで、黒画面が描画される
        yield return null;

        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 選択状態をリセット
        EventSystem.current.SetSelectedGameObject(null);

        // タグで新しいボタンを探す
        firstButton = GameObject.FindWithTag("FirstSelectable");

        if (scene.name == "GameScene")
        {
            // ゲームシーンではフェード画像を非表示にする
            if (fadeImage != null)
            {
                fadeImage.gameObject.SetActive(false);
            }
        }
        else
        {
            // 他のシーンではフェードインを行う
            if (fadeImage != null)
            {
                fadeImage.gameObject.SetActive(true);
                StartCoroutine(FadeIn());
            }
        }
    }

}

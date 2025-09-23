using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FadeManager : MonoBehaviour
{
    public Image fadeImage; // �t�F�[�h�p�̕ϐ�
    public float fadeDuration = 1.0f; // �t�F�[�h�̊Ԋu
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

    // �R���[�`���Ƃ�Update���g�킸�Ɏ��R�ȗ����
    // �������s�����߂̎d�g��

    // �t�F�[�h�C���̃R���[�`��
    void Awake()
    {
        // �V�[�����ς���Ă������Ȃ��悤�ɂ���
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
    // �t�F�[�h�C��
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }
    // IEnumerator�̓R���[�`�����g�����ߓ��ʂȖ߂�l�̌^
    // ���Ԃɉ��������o��������A
    // �r���ŏ������~�߂čĊJ���鏈���Ɏg����

    // �t�F�[�h�A�E�g�̃R���[�`��
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

    // �t�F�[�h�C��
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
              Debug.Log("FadeManager��������Ȃ��I");
         }
    }
}

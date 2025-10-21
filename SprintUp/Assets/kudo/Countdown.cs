using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text CountdownText;
    public int CountdownTime = 3; // カウントダウンの開始時間
    public AudioClip CountDownSE;
    public AudioClip StartSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(CountdownRoutine());
    }

    // Update is called once per frame
    IEnumerator CountdownRoutine() //時間経過に応じた処理を行うためにIEnumeratorを使用
    {
        while (CountdownTime > 0)
        {
            if ((CountdownTime <= 3) && (CountdownTime > 0))
            {
                CountdownText.text = CountdownTime.ToString();
                audioSource.PlayOneShot(CountDownSE);
            }
            yield return new WaitForSeconds(1f);// 1秒待つ
            CountdownTime--;
        }
        CountdownText.text = "Start!";
        audioSource.PlayOneShot(StartSE);
        GameData.isCanControll = true;
        yield return new WaitForSeconds(1f);
        CountdownText.gameObject.SetActive(false);// カウントダウンが終了したらテキストを非表示にする
    }
}

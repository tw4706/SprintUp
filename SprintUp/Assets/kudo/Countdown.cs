using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text CountdownText;
    public int CountdownTime = 3; // カウントダウンの開始時間

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(CountdownRoutine());
    }

    // Update is called once per frame
    IEnumerator CountdownRoutine() //時間経過に応じた処理を行うためにIEnumeratorを使用
    {
        while (CountdownTime > 0)
        {
            CountdownText.text = CountdownTime.ToString();
            yield return new WaitForSeconds(1f);// 1秒待つ
            CountdownTime--;
        }
        CountdownText.text = "Start!";
        yield return new WaitForSeconds(1f);

        CountdownText.gameObject.SetActive(false);// カウントダウンが終了したらテキストを非表示にする
    }
}

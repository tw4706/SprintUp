using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GameData
{
    public static bool is1PWin = false;      // true:プレイヤー1の勝ち   false:プレイヤー2の勝ち
    public static bool isDraw = false;
    public static float p1alt = 0.0f;   // プレイヤー1の高度
    public static float p2alt = 0.0f;   // プレイヤー2の高度
    public static bool isCanControll = false;
}

public class GameSceneSystem : MonoBehaviour
{
    Text timeUI;
    Text p1alt;
    Text p2alt;
    GameObject player1;
    GameObject player2;
    public GameObject BGMPlayer;
    AudioSource audioSourceBGM;
    bool isPlayedBGM = false;

    public FadeManager fadeManager;
    public GameObject explosionEffect;

    public float time = 60.0f;
    float maxTime = 0;

    public float AltitudeOffset = 0;

    float player1PosY = 0.0f;
    float player2PosY = 0.0f;
    float timeOverAfterTime = 0.0f;
    bool isEffected = false;
    Transform DefeatPlayerTransform;

    bool isTimeWarned = false;
    AudioSource audioSource;
    public AudioClip explosionSE;
    public AudioClip TimeOverSE;
    public AudioClip TimeWarningSE;
    public AudioClip EnterSE;

    public Image TutorialImage;
    bool isFirstStoped = false;
    bool isFirstPressed = false;

    void Start()
    {
        timeUI = GameObject.Find("TimeText").GetComponent<Text>();
        p1alt = GameObject.Find("1PAltitude").GetComponent<Text>();
        p2alt = GameObject.Find("2PAltitude").GetComponent<Text>();
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");
        timeOverAfterTime = 0.0f;
        isEffected = false;
        GameData.isCanControll = false;
        maxTime = time;
        time += 4;
        audioSource = this.GetComponent<AudioSource>();
        audioSourceBGM = BGMPlayer.GetComponent<AudioSource>();
    }

    void Update()
    {
        time -= Time.deltaTime;     // 制限時間を減らす

        // 最初の操作方法表示のための停止とか諸々
        if (time < maxTime + 3.2f)
        {
            if (!isFirstStoped)
            {
                Time.timeScale = 0;
                isFirstStoped = true;
            }

            if (TutorialImage.rectTransform.anchoredPosition.x > 0)
            {
                TutorialImage.rectTransform.anchoredPosition += Vector2.left * 10000 * Time.unscaledDeltaTime;
            }
            else if (!isFirstPressed)
            {
                TutorialImage.rectTransform.anchoredPosition = Vector2.zero;
            }
            else if (TutorialImage.rectTransform.anchoredPosition.x > -1800)
            {
                TutorialImage.rectTransform.anchoredPosition += Vector2.left * 10000 * Time.unscaledDeltaTime;
            }

            if (Input.GetKeyDown("joystick button 0") && !isFirstPressed)
            {
                audioSource.PlayOneShot(EnterSE);
                isFirstPressed = true;
                Time.timeScale = 1;
            }
        }

        if (time > maxTime)
        {
            timeUI.text = $"Time:{maxTime:F2}";    // 制限時間を表示(カウントダウン中なので設定した時間で固定)
        }
        else if(time > 0)
        {
            timeUI.text = $"Time:{time:F2}";    // 制限時間を表示(カウントダウン後なので普通に表示)
        }
        
        // カウントダウン中の良い感じのタイミングでBGMを再生開始
        if ((time < maxTime + 1) && !isPlayedBGM)
        {
            audioSourceBGM.Play();
            isPlayedBGM = true;
        }

        // プレイヤーの高度を表示
        p1alt.text = $"1P:{GameData.p1alt:F1}m";    
        p2alt.text = $"2P:{GameData.p2alt:F1}m";

        if (DefeatPlayerTransform != null)  // 負けたプレイヤーが存在していたら
        {
            Vector3 ababa = DefeatPlayerTransform.position;     // そのプレイヤーの位置を保存
            Debug.Log(ababa);   // 保存した位置をデバッグ表示
        }

        if ((time < 10) && !isTimeWarned)
        {
            timeUI.color = Color.red;
            audioSource.PlayOneShot(TimeWarningSE);
            isTimeWarned = true;
        }
        if (time < 10 && time > 5)
        {
            audioSourceBGM.pitch += Time.deltaTime * 0.05f;
        }

        // 時間切れ
        if (time < 0)
        {
            timeUI.text = $"Time:0.00";    // 制限時間を0.00秒にする
            // 距離の差が0.1以下なら引き分け
            float tempPosY = kirisute(player1PosY) - kirisute(player2PosY);
            if (Mathf.Abs(tempPosY) < 0.1f)
            {
                GameData.isDraw = true;
                Debug.Log("引き分け条件を満たしました");
            }
            else
            {
                GameData.isDraw = false;
            }

            // プレイヤーの高さを比較
            if (player1PosY > player2PosY)
            {
                // 1Pの方が高い
                GameData.is1PWin = true;
                //Debug.Log("1Pたかい");
                if (player2 != null)    // 負けた2Pの位置を保存
                {
                    DefeatPlayerTransform = player2.transform;
                }
                //Destroy(player2);
            }
            else
            {
                // 2Pの方が高い
                GameData.is1PWin = false;
                //Debug.Log("2Pたかい");
                if (player1 != null)
                {
                    DefeatPlayerTransform = player1.transform;
                }
                //Destroy(player1);
            }

            GameData.isCanControll = false;
            timeOverAfterTime += Time.deltaTime;
            audioSourceBGM.Stop();

            if (!isEffected)
            {
                Instantiate(explosionEffect, DefeatPlayerTransform);
                Instantiate(explosionEffect, DefeatPlayerTransform);
                Instantiate(explosionEffect, DefeatPlayerTransform);
                audioSource.PlayOneShot(explosionSE);
                audioSource.PlayOneShot(TimeOverSE);
                isEffected = true;
            }

            if (timeOverAfterTime > 2)
            {
                fadeManager.ChangeScene("ResultScene");
            }
            time = 0;
        }
        else
        {
            player1PosY = player1.transform.position.y;
            player2PosY = player2.transform.position.y;
            GameData.p1alt = player1.transform.position.y - AltitudeOffset;
            GameData.p2alt = player2.transform.position.y - AltitudeOffset;
        }
    }

    /// <summary>
    /// 小数点第一位以下を切り捨てる関数
    /// </summary>
    /// <param name="a">切り捨てる数字</param>
    /// <returns>切り捨てられた数字</returns>
    float kirisute(float a)
    {
        float ans;
        ans = a * 10;
        int temp = (int)ans;
        ans = temp;
        ans = ans / 10;
        return ans;
    }
}

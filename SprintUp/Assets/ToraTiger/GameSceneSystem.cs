using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GameData
{
    public static bool is1PWin = false;      // true:プレイヤー1の勝ち   false:プレイヤー2の勝ち
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

    public GameObject explosionEffect;

    public float time = 60.0f;
    float maxTime = 0;

    public float AltitudeOffset = 0;

    //public FadeManager fadeManager;

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
        time += 3;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        time -= Time.deltaTime;     // 制限時間を減らす
        if (time > maxTime)
        {
            timeUI.text = $"Time:{maxTime:F2}";    // 制限時間を表示
        }
        else if(time > 0)
        {
            timeUI.text = $"Time:{time:F2}";    // 制限時間を表示
        }

        p1alt.text = $"1P:{GameData.p1alt:F1}m";    // プレイヤーの高度を表示
        p2alt.text = $"{GameData.p2alt:F1}m:2P";

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

        // 時間切れ
        if (time < 0)
        {   // プレイヤーの高さを比較
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
                SceneManager.LoadScene("ResultScene");
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
}

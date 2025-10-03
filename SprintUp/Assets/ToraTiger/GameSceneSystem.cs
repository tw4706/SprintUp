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
}

public class GameSceneSystem : MonoBehaviour
{
    Text timeUI;
    Text p1alt;
    Text p2alt;
    GameObject player1;
    GameObject player2;

    public float time = 60.0f;

    public float AltitudeOffset = 0;

    public FadeManager fadeManager;

    void Start()
    {
        timeUI = GameObject.Find("TimeText").GetComponent<Text>();
        p1alt = GameObject.Find("1PAltitude").GetComponent<Text>();
        p2alt = GameObject.Find("2PAltitude").GetComponent<Text>();
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");


    }

    void Update()
    {
        time -= Time.deltaTime;
        timeUI.text = $"Time:{time:F2}";

        GameData.p1alt = player1.transform.position.y - AltitudeOffset;
        GameData.p2alt = player2.transform.position.y - AltitudeOffset;

        p1alt.text = $"1P:{GameData.p1alt:F1}m";
        p2alt.text = $"{GameData.p2alt:F1}m:2P";

        // 時間切れ
        if (time < 0)
        {   // プレイヤーの高さを比較
            if (player1.transform.position.y > player2.transform.position.y)
            {
                // 1Pの方が高い
                GameData.is1PWin = true;
                Debug.Log("1Pたかい");
            }
            else
            {
                // 2Pの方が高い
                GameData.is1PWin = false;
                Debug.Log("2Pたかい");
            }
            SceneManager.LoadScene("ResultScene");
        }

    }
}

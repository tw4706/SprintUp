using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GameData
{
    public static bool is1PWin = false;      // true:�v���C���[1�̏���   false:�v���C���[2�̏���
    public static float p1alt = 0.0f;   // �v���C���[1�̍��x
    public static float p2alt = 0.0f;   // �v���C���[2�̍��x
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

    public float AltitudeOffset = 0;

    public FadeManager fadeManager;

    float player1PosY = 0.0f;
    float player2PosY = 0.0f;
    float timeOverAfterTime = 0.0f;
    bool isEffected = false;
    Transform DefeatPlayerTransform;

    void Start()
    {
        timeUI = GameObject.Find("TimeText").GetComponent<Text>();
        p1alt = GameObject.Find("1PAltitude").GetComponent<Text>();
        p2alt = GameObject.Find("2PAltitude").GetComponent<Text>();
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");
        timeOverAfterTime = 0.0f;
        isEffected = false;

    }

    void Update()
    {
        time -= Time.deltaTime;
        timeUI.text = $"Time:{time:F2}";

        p1alt.text = $"1P:{GameData.p1alt:F1}m";
        p2alt.text = $"{GameData.p2alt:F1}m:2P";

        if (DefeatPlayerTransform != null)
        {
            Vector3 ababa = DefeatPlayerTransform.position;
            Debug.Log(ababa);
        }

        // ���Ԑ؂�
        if (time < 0)
        {   // �v���C���[�̍������r
            if (player1PosY > player2PosY)
            {
                // 1P�̕�������
                GameData.is1PWin = true;
                //Debug.Log("1P������");
                if (player2 != null)
                {
                    DefeatPlayerTransform = player2.transform;
                }
                Destroy(player2);
            }
            else
            {
                // 2P�̕�������
                GameData.is1PWin = false;
                //Debug.Log("2P������");
                if (player1 != null)
                {
                    DefeatPlayerTransform = player1.transform;
                }
                Destroy(player1);
            }

            timeOverAfterTime += Time.deltaTime;

            if (!isEffected)
            {
                Instantiate(explosionEffect, DefeatPlayerTransform);
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

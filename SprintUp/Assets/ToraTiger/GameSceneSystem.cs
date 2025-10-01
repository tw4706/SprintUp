using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneSystem : MonoBehaviour
{
    Text timeUI;
    Text p1alt;
    Text p2alt;
    GameObject player1;
    GameObject player2;

    public float time = 60.0f;

    public float AltitudeOffset = 0;

    bool is1PWin = true;

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

        p1alt.text = $"1P:{player1.transform.position.y - AltitudeOffset:F1}";
        p2alt.text = $"{player2.transform.position.y - AltitudeOffset:F1}:2P";

        // éûä‘êÿÇÍ
        if (time < 0)
        {   // ÉvÉåÉCÉÑÅ[ÇÃçÇÇ≥Çî‰är
            if (player1.transform.position.y > player2.transform.position.y)
            {
                // 1PÇÃï˚Ç™çÇÇ¢
                is1PWin = true;
                Debug.Log("1PÇΩÇ©Ç¢");
            }
            else
            {
                // 2PÇÃï˚Ç™çÇÇ¢
                is1PWin = false;
                Debug.Log("2PÇΩÇ©Ç¢");
            }
        }

    }
}

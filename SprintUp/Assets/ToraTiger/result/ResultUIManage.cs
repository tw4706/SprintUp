using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManage : MonoBehaviour
{
    Text WinText;
    Text Alt1;
    Text Alt2;
    Text DrawAlt1;
    Text DrawAlt2;

    void Start()
    {
        WinText = GameObject.Find("nPWin").GetComponent<Text>();
        Alt1 = GameObject.Find("Altitude1").GetComponent<Text>();
        Alt2 = GameObject.Find("Altitude2").GetComponent<Text>();
        DrawAlt1 = GameObject.Find("DrawAltitude1").GetComponent<Text>();
        DrawAlt2 = GameObject.Find("DrawAltitude2").GetComponent<Text>();
        if (GameData.isDraw)
        {
            WinText.text = "Draw!";
            DrawAlt1.text = $"{GameData.p1alt:F1}m";
            DrawAlt2.text = $"{GameData.p1alt:F1}m";
            Alt1.text = "";
            Alt2.text = "";
        }
        else if (GameData.is1PWin)
        {
            WinText.text = "1P Win!";
            Alt1.text = $"{GameData.p1alt:F1}m";
            Alt2.text = $"{GameData.p2alt:F1}m";
        }
        else
        {
            WinText.text = "2P Win!";
            Alt1.text = $"{GameData.p2alt:F1}m";
            Alt2.text = $"{GameData.p1alt:F1}m";
        }

    }

    
    void Update()
    {
        
    }
}

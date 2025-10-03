using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManage : MonoBehaviour
{
    Text WinText;
    Text ResultAlt1;
    Text ResultAlt2;

    void Start()
    {
        WinText = GameObject.Find("nPWin").GetComponent<Text>();
        ResultAlt1 = GameObject.Find("Altitude1").GetComponent<Text>();
        ResultAlt2 = GameObject.Find("Altitude2").GetComponent<Text>();
        if (GameData.is1PWin)
        {
            WinText.text = "1P Win!";
            ResultAlt1.text = $"{GameData.p1alt:F1}m";
            ResultAlt2.text = $"{GameData.p2alt:F1}m";
        }
        else
        {
            WinText.text = "2P Win!";
            ResultAlt1.text = $"{GameData.p2alt:F1}m";
            ResultAlt2.text = $"{GameData.p1alt:F1}m";
        }

    }

    
    void Update()
    {
        
    }
}

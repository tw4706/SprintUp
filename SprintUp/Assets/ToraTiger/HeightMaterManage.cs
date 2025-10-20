using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightMaterManage : MonoBehaviour
{
    const float kMinHeight = -200.0f;
    const float kMaxHeight = 200.0f;
    const float kPosX1P = -70;
    const float kPosX2P = 70;

    public GameObject Player1P;
    public GameObject Player2P;
    public RectTransform AltImage1P;
    public RectTransform AltImage2P;

    public float OffsetY;
    public float IncreaseRate;

    void Start()
    {
        
    }

    void Update()
    {
        float p1PosY = Player1P.transform.position.y * IncreaseRate + OffsetY;
        float p2PosY = Player2P.transform.position.y * IncreaseRate + OffsetY;
        AltImage1P.anchoredPosition = new Vector3(kPosX1P, p1PosY, 0);
        AltImage2P.anchoredPosition = new Vector3(kPosX2P, p2PosY, 0);
    }
}

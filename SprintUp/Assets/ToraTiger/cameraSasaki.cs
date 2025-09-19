using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSasaki : MonoBehaviour
{
    public Transform playerPos;
    public float offsetX = 0f;
    public float offsetY = 1f;
    public float offsetZ = -5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = playerPos.position;
        pos.x += offsetX;
        pos.y += offsetY;
        pos.z += offsetZ;
        transform.position = pos;
        transform.LookAt(playerPos);
    }
}

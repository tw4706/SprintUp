using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrap : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player2P");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton2))
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < 1.0f)
            {
                player.transform.position = this.transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    private Vector3 respawnPoint;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;   //位置を保存する
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;   //動きをリセットする
        rb.angularVelocity = Vector3.zero;

        transform.position = respawnPoint;  //チェックポイントに移動
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)  //プレイヤーがある程度落下するとチェックポイントに移動
        {
            Respawn();
        }
    }
}

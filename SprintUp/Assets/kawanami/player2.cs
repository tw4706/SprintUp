using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    float inputHorizotal;
    float inputVertical;
    Rigidbody rb;

    float moveSpeed =3.0f;

    public Camera Camera2;
    void Start()
    {
        //キャラクターコントローラー取得
        rb = GetComponent<Rigidbody>();

        //速度をゼロに設定
        //this.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizotal = Input.GetAxisRaw("Horizontal2");
        inputVertical = Input.GetAxisRaw("Vertical2");


        

    }

    private void FixedUpdate()
    {
        //カメラの方向からx-z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(-Camera2.transform.forward, new Vector3(1, 0, 1)).normalized;

        //方向キーの入力値とカメラの向きから移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera2.transform.right * inputHorizotal;

        //移動方向にスピードをかける。ジャンプや落下がある場合は別途Y軸方向の速度ベクトルを足す
        rb.velocity = moveForward*moveSpeed+new Vector3(0, rb.velocity.y, 0);

        //キャラクターの向きを進行方向に
        if(moveForward!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}

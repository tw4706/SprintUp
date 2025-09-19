using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    float inputHorizotal;
    float inputVertical;
    Rigidbody rb;

    float moveSpeed =3.0f;

    public Camera Camera1;
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
        inputHorizotal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


        //Vector3 vec = this.velocity;
        //float speed = 0.0f;
        
        ////床に設置していたら移動
        //if(this.controller.isGrounded)
        //{
        //    //ゲームパッドのスティック入力値を取得して移動ベクトルを作成
        //    //設置しているのでY軸の値をリセット
        //    vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //    //入力値から得たベクトルの長さが0.1fを超えていれば速さを設定
        //    if(vec.magnitude>0.1f)
        //    {
        //        //スティックの倒し具合によって速さを変更
        //        speed = Mathf.Lerp(this.minspeed, this.maxspeed, vec.magnitude);

        //        //向きの変更
        //        Vector3 dir = vec.normalized;
        //        float rotate = Mathf.Acos(dir.z);
        //        if(dir.x<0)rotate = -rotate;
        //        rotate *= Mathf.Rad2Deg;
        //        Quaternion q = Quaternion.Euler(0, rotate, 0);
               
        //    }

        //    //移動ベクトルを正規化
        //    vec = vec.normalized;

        //}

        ////移動速度を設定
        //this.velocity.x = vec.x * speed;
        //this.velocity.y = vec.y ;
        //this.velocity.z = vec.z * speed;

        ////重力による落下を設定
        //this.velocity.y += Physics.gravity.y * Time.deltaTime;

        ////移動させる
        //this.controller.Move(this.velocity * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        //カメラの方向からx-z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera1.transform.forward, new Vector3(1, 0, 1)).normalized;

        //方向キーの入力値とカメラの向きから移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera1.transform.right * inputHorizotal;

        //移動方向にスピードをかける。ジャンプや落下がある場合は別途Y軸方向の速度ベクトルを足す
        rb.velocity = moveForward*moveSpeed+new Vector3(0, rb.velocity.y, 0);

        //キャラクターの向きを進行方向に
        if(moveForward!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}

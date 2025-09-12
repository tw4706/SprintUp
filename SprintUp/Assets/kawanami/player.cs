using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //速さの最低値
    private float minspeed = 3.0f;

    //速さの最高値
    private float maxspeed = 5.0f;

    //プレイヤーの方向転換スピードの調整値
    //[SerializeField, Range(0.0f, 1.0f)]
    //private float turnRate = 0.3f;

    //移動速度
    private Vector3 velocity;

    //キャラクターコントローラー
    private CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        //キャラクターコントローラー取得
        this.controller = GetComponent<CharacterController>();

        //速度をゼロに設定
        this.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = this.velocity;
        float speed = 0.0f;
        
        //床に設置していたら移動
        if(this.controller.isGrounded)
        {
            //ゲームパッドのスティック入力値を取得して移動ベクトルを作成
            //設置しているのでY軸の値をリセット
            vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            //入力値から得たベクトルの長さが0.1fを超えていれば速さを設定
            if(vec.magnitude>0.1f)
            {
                //スティックの倒し具合によって速さを変更
                speed = Mathf.Lerp(this.minspeed, this.maxspeed, vec.magnitude);

                //向きの変更
                Vector3 dir = vec.normalized;
                float rotate = Mathf.Acos(dir.z);
                if(dir.x<0)rotate = -rotate;
                rotate *= Mathf.Rad2Deg;
                Quaternion q = Quaternion.Euler(0, rotate, 0);
                //ここでモデルの向いている方向が徐々に変わるようにしつつ
                //モデルの向きを変更
                //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, q, this.turnRate);

            }

            //移動ベクトルを正規化
            vec = vec.normalized;

        }

        //移動速度を設定
        this.velocity.x = vec.x * speed;
        this.velocity.y = vec.y ;
        this.velocity.z = vec.z * speed;

        //重力による落下を設定
        this.velocity.y += Physics.gravity.y * Time.deltaTime;

        //移動させる
        this.controller.Move(this.velocity * Time.deltaTime);

    }
}

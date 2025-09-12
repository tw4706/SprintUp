using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 定数
    const float kMoveSpeed = 2.0f;      // 移動速度
    const float kMaxMoveSpeed = 2.0f;   // 最高移動速度
    const float kFrictionForce = 2.0f;  // 自然に止まる力

    Vector3 speed = Vector3.zero;
    public bool isMoveAnim = false;

    void Start()
    {
        
    }

    void Update()
    {
        //speed = Vector3.zero;
        // 入力を取得して速度に変換
        InputSpeed();
        Debug.Log($"input:{speed}");

        // 最高速度に補正&自然に止まる力
        //CorrectSpeed();

        // 位置に速度を足す
        Vector3 pos = transform.position;
        pos += speed;
        transform.position = pos;
    }

    void InputSpeed()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        speed += moveVec * kMoveSpeed * Time.deltaTime;
    }

    void CorrectSpeed()
    {
        // 速度がある程度を下回ったら止める
        if (speed.x < 0.1f && speed.x > -0.1f)
        {
            speed.x = 0f;
        }
        if (speed.z < 0.1f && speed.z > -0.1f)
        {
            speed.z = 0f;
        }

        // 自然に止まる力
        if (speed.x > 0.1f)
        {
            speed.x -= kFrictionForce;
        }
        else if (speed.x < -0.1f)
        {
            speed.x += kFrictionForce;
        }

        if (speed.z > 0.1f)
        {
            speed.z -= kFrictionForce;
        }
        else if (speed.z < -0.1f)
        {
            speed.z += kFrictionForce;
        }

        // 最高速度を超えたら補正
        if (speed.x > kMaxMoveSpeed)
        {
            speed.x = kMaxMoveSpeed;
        }
        if (speed.x < -kMaxMoveSpeed)
        {
            speed.x = -kMaxMoveSpeed;
        }

        if (speed.z > kMaxMoveSpeed)
        {
            speed.z = kMaxMoveSpeed;
        }
        if (speed.z < -kMaxMoveSpeed)
        {
            speed.z = -kMaxMoveSpeed;
        }
    }

}

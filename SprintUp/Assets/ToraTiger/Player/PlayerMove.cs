using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 定数
    const float kMoveSpeed = 2.0f;      // 移動速度
    const float kDashSpeed = 3.5f;
    const float rotationSpeed = 720.0f;


    Rigidbody rb;
    Vector3 velocity = Vector3.zero;
    public int animationType = 0;  // 0:idle 1:jog 2:dash

    // ジャンプ関連
    public float checkDistance = 0.1f;
    public LayerMask groundLayer;
    public Transform bottom;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 入力方向を取得
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (Input.GetKey(KeyCode.JoystickButton5))  // R2ボタンが押されていたらダッシュ
        { 
            velocity = inputDir * kDashSpeed;
            animationType = 2;  // アニメーションをダッシュに変更
        }
        else
        {
            velocity = inputDir * kMoveSpeed; 
            animationType = 1;  // アニメーションをジョグに変更
        }

        // 入力があれば移動方向に向く
        if (velocity.sqrMagnitude > 0)
        {
            // 入力方向に向かう回転を計算
            Quaternion targetRotation = Quaternion.LookRotation(inputDir);

            // スムーズに回転
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime);

        }
        else    // 入力がなければアイドルアニメーションに変更
        {
            animationType = 0;  // idle
        }

        bool isGrounded = Physics.Raycast(bottom.position, Vector3.down, checkDistance, groundLayer);

        if (isGrounded)
        {
            Debug.Log("接地しています");
        }
        else
        {
            Debug.Log("空中です");
        }

        // Aボタンが押されたら
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && isGrounded)
        {
            isGrounded = false;  // ジャンプしたので地面から離れる
            rb.AddForce(Vector3.up * 5.0f, ForceMode.VelocityChange);  // ジャンプ
            //animationType = 3;  // アニメーションをジャンプに変更
        }

        Debug.Log($"velocity:{velocity}");

        // 移動
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, checkDistance, groundLayer);
    }

}
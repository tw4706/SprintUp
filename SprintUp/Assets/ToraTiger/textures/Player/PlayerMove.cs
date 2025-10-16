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
    const string kJumpKeyName = "joystick 1 button 0";


    public float kJumpPower = 7.0f;

    Rigidbody rb;
    Vector3 velocity = Vector3.zero;
    public int animationType = 0;  // 0:idle 1:jog 2:dash 3:jump

    public Transform cameraPos;

    // ジャンプ関連
    public float checkDistance = 0.15f;
    public LayerMask groundLayer;
    public Transform bottom;
    private bool isFalling = false;
    public bool IsFalling()
    {
        return isFalling;
    }

    Animator animator;


    // 移動音関係
    float footstepsCT = 0f;
    AudioSource audioSource;
    public AudioClip Footsteps;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontal = 0;
        float vertical = 0;
        bool isInputDash = false;
        bool isInputJump = false;
        if (GameData.isCanControll)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            isInputDash = Input.GetKey("joystick 1 button 5");
            isInputJump = Input.GetKeyDown(kJumpKeyName);
        }

        // カメラの向きに基づいた移動方向を計算
        Vector3 cameraForward = cameraPos.forward;
        Vector3 cameraRight = cameraPos.right;

        // Y軸方向の影響を除去
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDir = cameraForward * vertical + cameraRight * horizontal;

        if (isInputDash)  // R2ボタンが押されていたらダッシュ
        { 
            velocity = moveDir * kDashSpeed;
            animationType = 2;  // アニメーションをダッシュに変更
        }
        else
        {
            velocity = moveDir * kMoveSpeed; 
            animationType = 1;  // アニメーションをジョグに変更
        }

        // 足音
        footstepsCT += Time.deltaTime;
        if ((velocity.magnitude > 0) && !isFalling)
        {
            if (isInputDash)
            {
                if (footstepsCT > 0.27f)
                {
                    footstepsCT = 0f;
                    audioSource.PlayOneShot(Footsteps);
                }
            }
            else if (footstepsCT > 0.43f)
            {
                footstepsCT = 0f;
                audioSource.PlayOneShot(Footsteps);
            }
        }

        // 入力があれば移動方向に向く
        if (velocity.sqrMagnitude > 0)
        {
            // 入力方向に向かう回転を計算
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

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


       bool isGround = Physics.Raycast(bottom.position, Vector3.down, checkDistance, groundLayer);

        // Aボタンが押されたら
        if (isInputJump && isGround)
        {
            //Debug.Log("ジャンプしてるんじゃぁ");
            isGround = false;  // ジャンプしたので地面から離れる
            rb.AddForce(Vector3.up * kJumpPower, ForceMode.VelocityChange);  // ジャンプ
        }

        float yVelocity = rb.velocity.y;  // 現在のY方向の速度を保存
        if ((yVelocity < 0.05f) && (yVelocity > -0.05f))
        {
            isFalling = false;
        }
        else
        {
            isFalling = true;
        }

            //Debug.Log($"velocity:{velocity}");

        // 移動
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, checkDistance, groundLayer);
    }

}
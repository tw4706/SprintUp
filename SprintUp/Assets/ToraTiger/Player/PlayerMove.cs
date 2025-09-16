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
    public int animationType = 0;  // 0:idle 1:jog 2:dash 3:jump 4:fall 5:land

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.JoystickButton5))
        {
            //velocity = inputDir * kDashSpeed;
            rb.MovePosition(rb.position + inputDir * kDashSpeed * Time.deltaTime);
            animationType = 2;  // dash
        }
        else
        {
            //velocity = inputDir * kMoveSpeed;
            rb.MovePosition(rb.position + inputDir * kMoveSpeed * Time.deltaTime);
            animationType = 1;  // jog
        }

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
        else
        {
            animationType = 0;  // idle
        }

        if (Input.GetKey(KeyCode.JoystickButton0))
        {

        }

        Debug.Log($"animationType:{animationType}");

        Vector3 pos = transform.position;
        pos += velocity * Time.deltaTime;
        transform.position = pos;
    }

    void CorrectSpeed()
    {

    }

}

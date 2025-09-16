using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �萔
    const float kMoveSpeed = 2.0f;      // �ړ����x
    const float kDashSpeed = 3.5f;
    const float rotationSpeed = 720.0f;

    Vector3 velocity = Vector3.zero;
    public int animationType = 0;  // 0:idle 1:jog 2:dash

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.JoystickButton5))
        {
            velocity = inputDir * kDashSpeed;
            animationType = 2;  // dash
        }
        else
        {
            velocity = inputDir * kMoveSpeed;
            animationType = 1;  // jog
        }

        if (velocity.sqrMagnitude > 0)
        {
            // ���͕����Ɍ�������]���v�Z
            Quaternion targetRotation = Quaternion.LookRotation(inputDir);

            // �X���[�Y�ɉ�]
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime);

        }
        else
        {
            animationType = 0;  // idle
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

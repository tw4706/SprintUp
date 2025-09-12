using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �萔
    const float kMoveSpeed = 2.0f;      // �ړ����x
    const float kMaxMoveSpeed = 2.0f;   // �ō��ړ����x
    const float kFrictionForce = 2.0f;  // ���R�Ɏ~�܂��

    Vector3 speed = Vector3.zero;
    public bool isMoveAnim = false;

    void Start()
    {
        
    }

    void Update()
    {
        //speed = Vector3.zero;
        // ���͂��擾���đ��x�ɕϊ�
        InputSpeed();
        Debug.Log($"input:{speed}");

        // �ō����x�ɕ␳&���R�Ɏ~�܂��
        //CorrectSpeed();

        // �ʒu�ɑ��x�𑫂�
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
        // ���x��������x�����������~�߂�
        if (speed.x < 0.1f && speed.x > -0.1f)
        {
            speed.x = 0f;
        }
        if (speed.z < 0.1f && speed.z > -0.1f)
        {
            speed.z = 0f;
        }

        // ���R�Ɏ~�܂��
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

        // �ō����x�𒴂�����␳
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

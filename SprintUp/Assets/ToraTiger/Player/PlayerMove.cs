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


    Rigidbody rb;
    Vector3 velocity = Vector3.zero;
    public int animationType = 0;  // 0:idle 1:jog 2:dash

    public Transform camera;

    // �W�����v�֘A
    public float checkDistance = 0.1f;
    public LayerMask groundLayer;
    public Transform bottom;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���͕������擾
        //Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �J�����̌����Ɋ�Â����ړ��������v�Z
        Vector3 cameraForward = camera.forward;
        Vector3 cameraRight = camera.right;

        // Y�������̉e��������
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDir = cameraForward * vertical + cameraRight * horizontal;

        if (Input.GetKey(KeyCode.JoystickButton5))  // R2�{�^����������Ă�����_�b�V��
        { 
            velocity = moveDir * kDashSpeed;
            animationType = 2;  // �A�j���[�V�������_�b�V���ɕύX
        }
        else
        {
            velocity = moveDir * kMoveSpeed; 
            animationType = 1;  // �A�j���[�V�������W���O�ɕύX
        }

        // ���͂�����Έړ������Ɍ���
        if (velocity.sqrMagnitude > 0)
        {
            // ���͕����Ɍ�������]���v�Z
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            // �X���[�Y�ɉ�]
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime);

        }
        else    // ���͂��Ȃ���΃A�C�h���A�j���[�V�����ɕύX
        {
            animationType = 0;  // idle
        }

        bool isGrounded = Physics.Raycast(bottom.position, Vector3.down, checkDistance, groundLayer);

        if (isGrounded)
        {
            Debug.Log("�ڒn���Ă��܂�");
        }
        else
        {
            Debug.Log("�󒆂ł�");
        }

        // A�{�^���������ꂽ��
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && isGrounded)
        {
            isGrounded = false;  // �W�����v�����̂Œn�ʂ��痣���
            rb.AddForce(Vector3.up * 5.0f, ForceMode.VelocityChange);  // �W�����v
            //animationType = 3;  // �A�j���[�V�������W�����v�ɕύX
        }

        Debug.Log($"velocity:{velocity}");

        // �ړ�
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, checkDistance, groundLayer);
    }

}
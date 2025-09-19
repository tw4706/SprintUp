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
        //�L�����N�^�[�R���g���[���[�擾
        rb = GetComponent<Rigidbody>();

        //���x���[���ɐݒ�
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
        //�J�����̕�������x-z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(-Camera2.transform.forward, new Vector3(1, 0, 1)).normalized;

        //�����L�[�̓��͒l�ƃJ�����̌�������ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera2.transform.right * inputHorizotal;

        //�ړ������ɃX�s�[�h��������B�W�����v�◎��������ꍇ�͕ʓrY�������̑��x�x�N�g���𑫂�
        rb.velocity = moveForward*moveSpeed+new Vector3(0, rb.velocity.y, 0);

        //�L�����N�^�[�̌�����i�s������
        if(moveForward!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}

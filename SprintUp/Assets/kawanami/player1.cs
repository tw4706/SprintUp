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
        //�L�����N�^�[�R���g���[���[�擾
        rb = GetComponent<Rigidbody>();

        //���x���[���ɐݒ�
        //this.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizotal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


        //Vector3 vec = this.velocity;
        //float speed = 0.0f;
        
        ////���ɐݒu���Ă�����ړ�
        //if(this.controller.isGrounded)
        //{
        //    //�Q�[���p�b�h�̃X�e�B�b�N���͒l���擾���Ĉړ��x�N�g�����쐬
        //    //�ݒu���Ă���̂�Y���̒l�����Z�b�g
        //    vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //    //���͒l���瓾���x�N�g���̒�����0.1f�𒴂��Ă���Α�����ݒ�
        //    if(vec.magnitude>0.1f)
        //    {
        //        //�X�e�B�b�N�̓|����ɂ���đ�����ύX
        //        speed = Mathf.Lerp(this.minspeed, this.maxspeed, vec.magnitude);

        //        //�����̕ύX
        //        Vector3 dir = vec.normalized;
        //        float rotate = Mathf.Acos(dir.z);
        //        if(dir.x<0)rotate = -rotate;
        //        rotate *= Mathf.Rad2Deg;
        //        Quaternion q = Quaternion.Euler(0, rotate, 0);
               
        //    }

        //    //�ړ��x�N�g���𐳋K��
        //    vec = vec.normalized;

        //}

        ////�ړ����x��ݒ�
        //this.velocity.x = vec.x * speed;
        //this.velocity.y = vec.y ;
        //this.velocity.z = vec.z * speed;

        ////�d�͂ɂ�闎����ݒ�
        //this.velocity.y += Physics.gravity.y * Time.deltaTime;

        ////�ړ�������
        //this.controller.Move(this.velocity * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        //�J�����̕�������x-z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera1.transform.forward, new Vector3(1, 0, 1)).normalized;

        //�����L�[�̓��͒l�ƃJ�����̌�������ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera1.transform.right * inputHorizotal;

        //�ړ������ɃX�s�[�h��������B�W�����v�◎��������ꍇ�͕ʓrY�������̑��x�x�N�g���𑫂�
        rb.velocity = moveForward*moveSpeed+new Vector3(0, rb.velocity.y, 0);

        //�L�����N�^�[�̌�����i�s������
        if(moveForward!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}

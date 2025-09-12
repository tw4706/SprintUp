using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //�����̍Œ�l
    private float minspeed = 3.0f;

    //�����̍ō��l
    private float maxspeed = 5.0f;

    //�v���C���[�̕����]���X�s�[�h�̒����l
    //[SerializeField, Range(0.0f, 1.0f)]
    //private float turnRate = 0.3f;

    //�ړ����x
    private Vector3 velocity;

    //�L�����N�^�[�R���g���[���[
    private CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        //�L�����N�^�[�R���g���[���[�擾
        this.controller = GetComponent<CharacterController>();

        //���x���[���ɐݒ�
        this.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = this.velocity;
        float speed = 0.0f;
        
        //���ɐݒu���Ă�����ړ�
        if(this.controller.isGrounded)
        {
            //�Q�[���p�b�h�̃X�e�B�b�N���͒l���擾���Ĉړ��x�N�g�����쐬
            //�ݒu���Ă���̂�Y���̒l�����Z�b�g
            vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            //���͒l���瓾���x�N�g���̒�����0.1f�𒴂��Ă���Α�����ݒ�
            if(vec.magnitude>0.1f)
            {
                //�X�e�B�b�N�̓|����ɂ���đ�����ύX
                speed = Mathf.Lerp(this.minspeed, this.maxspeed, vec.magnitude);

                //�����̕ύX
                Vector3 dir = vec.normalized;
                float rotate = Mathf.Acos(dir.z);
                if(dir.x<0)rotate = -rotate;
                rotate *= Mathf.Rad2Deg;
                Quaternion q = Quaternion.Euler(0, rotate, 0);
                //�����Ń��f���̌����Ă�����������X�ɕς��悤�ɂ���
                //���f���̌�����ύX
                //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, q, this.turnRate);

            }

            //�ړ��x�N�g���𐳋K��
            vec = vec.normalized;

        }

        //�ړ����x��ݒ�
        this.velocity.x = vec.x * speed;
        this.velocity.y = vec.y ;
        this.velocity.z = vec.z * speed;

        //�d�͂ɂ�闎����ݒ�
        this.velocity.y += Physics.gravity.y * Time.deltaTime;

        //�ړ�������
        this.controller.Move(this.velocity * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    private Vector3 respawnPoint;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;   //�ʒu��ۑ�����
    }

    public void Respawn()
    {
        rb.velocity = Vector3.zero;   //���������Z�b�g����
        rb.angularVelocity = Vector3.zero;

        transform.position = respawnPoint;  //�`�F�b�N�|�C���g�Ɉړ�
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)  //�v���C���[��������x��������ƃ`�F�b�N�|�C���g�Ɉړ�
        {
            Respawn();
        }
    }
}

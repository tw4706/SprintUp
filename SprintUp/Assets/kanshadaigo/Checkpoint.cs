using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //�`�F�b�N�|�C���g�̈ʒu��ۑ�
            CheckpointManager.Instance.SetCheckpoint(transform.position);
            Debug.Log("�`�F�b�N�|�C���g�ɓ��B:" +  transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Respawn()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

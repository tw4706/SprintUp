using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //チェックポイントの位置を保存
            CheckpointManager.Instance.SetCheckpoint(transform.position);
            Debug.Log("チェックポイントに到達:" +  transform.position);
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

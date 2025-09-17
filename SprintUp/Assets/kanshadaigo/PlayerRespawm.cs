using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawm : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        //Vector3 CheckpointPos = CheckpointManager.Instance.GetCheckpointPosition();
        //transform.position = CheckpointPos;
        //Debug.Log("チェックポイントに到達した:" +  CheckpointPos);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}

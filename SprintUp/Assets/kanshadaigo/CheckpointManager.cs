using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private Vector3 checkpointPosition;

    private void Awake()
    {
        if(Instance == null )
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  //�V�[�����؂�ւ���Ă��`�F�b�N�|�C���g�̕ۑ��̓��Z�b�g����Ȃ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpointPosition(Vector3 pos)
    {
        checkpointPosition = pos;
    }

    public Vector3 GetCheckpointPosition()
    {
        return checkpointPosition;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

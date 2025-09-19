using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // �{�^��
    public Button _button;
    // �V�[���J�ڐ�
    public string scene;
    // �X�^�[�g���Ă��邩�ǂ���
    //bool isStart = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(_button==null)
        {
            _button = GetComponent<Button>();
        }
        // �{�^�����N���b�N���ꂽ�ۂɌĂяo�����֐�
        _button.onClick.AddListener(OnButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnButtonClick()
    {
        Debug.Log("�{�^����������");
        SceneManager.LoadScene(scene);
    }
}

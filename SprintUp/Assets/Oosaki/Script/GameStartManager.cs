using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // ボタン
    public Button _button;
    // シーン遷移先
    public string scene;
    // スタートしているかどうか
    //bool isStart = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(_button==null)
        {
            _button = GetComponent<Button>();
        }
        // ボタンがクリックされた際に呼び出される関数
        _button.onClick.AddListener(OnButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnButtonClick()
    {
        Debug.Log("ボタンを押した");
        SceneManager.LoadScene(scene);
    }
}

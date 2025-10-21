using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManage : MonoBehaviour
{
    public Image StartImage;
    public Image EndImage;
    public FadeManager FadeManager;
    public AudioClip EnterSE;
    public AudioClip SelectSE;

    AudioSource audioSource;

    // true:スタートを選択している / false:終了を選択している
    bool isSelectStart = true;
    bool isPressed = false;
    float dPadY;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 十字キーの上下を取得
        float prevDPadY = dPadY;
        dPadY = Input.GetAxis("DPad_YAxis");

        if (!isPressed)
        {
            if (dPadY == 1) // 上なら
            {
                if ((prevDPadY != dPadY) && !isSelectStart)
                {
                    audioSource.PlayOneShot(SelectSE);
                }
                isSelectStart = true;
            }
            if (dPadY == -1)    // 下なら
            {
                if ((prevDPadY != dPadY) && isSelectStart)
                {
                    audioSource.PlayOneShot(SelectSE);
                }
                isSelectStart = false;
            }
        }

        if (isSelectStart)  // スタートボタンを選択
        {
            // 終了ボタンを半透明
            Color color = EndImage.color;
            color.a = 0.5f;
            EndImage.color = color;

            // スタートボタンを不透明
            color = StartImage.color;
            color.a = 1;
            StartImage.color = color;
            
            if (Input.GetKeyDown("joystick button 0") && !isPressed)
            {
                FadeManager.ChangeScene("GameScene");
                audioSource.PlayOneShot(EnterSE);
                isPressed = true;
            }
            
        }
        else // 終了ボタンを選択
        {
            // スタートボタンを半透明
            Color color = StartImage.color;
            color.a = 0.5f;
            StartImage.color = color;

            // 終了ボタンを不透明
            color = EndImage.color;
            color.a = 1;
            EndImage.color = color;

            if (Input.GetKeyDown("joystick button 0") && !isPressed)
            {
                FadeManager.GameEnd();
                audioSource.PlayOneShot(EnterSE);
                isPressed = true;
            }
        }
    }
}

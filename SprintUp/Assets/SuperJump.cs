using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public string JoystickName;
    public GameObject OtherPlayer;
    public GameObject SuperJumpUI;
    public GameObject ExplosionEffect;

    float JumpPower = 15.0f;
    Rigidbody rb;
    bool isCanSuperJump = false;
    float superJumpCT = 0f;

    float UIFrickTime = 0;

    bool isPlayedChargedSE = false;
    AudioSource audioSource;
    public AudioClip SuperJumpSE;
    public AudioClip SuperJumpChargedSE;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
        SuperJumpUI.SetActive(false);
    }

    void Update()
    {
        // スペースキーで即使用可能(デバッグ用)
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCanSuperJump = true;
        }
#endif

        // 高さを比較
        float posYDif = OtherPlayer.transform.position.y - this.transform.position.y;
        if ((posYDif > 10) && (superJumpCT == 0))
        {
            isCanSuperJump=true;
        }

        // クールタイム
        superJumpCT -= Time.deltaTime;
        if (superJumpCT < 0)
        {
            superJumpCT = 0;
        }

        // スーパージャンプする
        bool isInputSuperJump = false;
        isInputSuperJump = Input.GetKeyDown(JoystickName);
        if (GameData.isCanControll)
        {
            if (isInputSuperJump && isCanSuperJump)
            {
                rb.velocity = new Vector3(0, JumpPower, 0);
                audioSource.PlayOneShot(SuperJumpSE);
                Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
                SuperJumpUI.SetActive(false);
                superJumpCT = 10;
                isCanSuperJump = false;
                isPlayedChargedSE = false;
            }
        }
        

        // UI点滅
        if (isCanSuperJump)
        {
            UIFrickTime += Time.deltaTime;
            if (UIFrickTime > 0.5f)
            {
                SuperJumpUI.SetActive(true);
                if (UIFrickTime > 1)
                {
                    SuperJumpUI.SetActive(false);
                    UIFrickTime = 0;
                }
            }
            if (!isPlayedChargedSE)
            {
                audioSource.PlayOneShot(SuperJumpChargedSE);
                isPlayedChargedSE = true;
            }
        }
    }
}

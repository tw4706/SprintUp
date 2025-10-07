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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SuperJumpUI.SetActive(false);
    }

    void Update()
    {
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
        if(Input.GetKeyDown(JoystickName) && isCanSuperJump)
        {
            rb.velocity = new Vector3(0,JumpPower,0);
            Instantiate(ExplosionEffect,transform.position,Quaternion.identity);
            SuperJumpUI.SetActive(false);
            superJumpCT = 15;
            isCanSuperJump = false;
        }
        //Debug.Log(superJumpCT);

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
        }
    }
}

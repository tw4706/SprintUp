using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Result : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (GameData.is1PWin)
        {
            animator.SetBool("isWin",true);
            transform.position = new Vector3(0, -0.3f, -7);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            animator.SetBool("isWin", false);
            transform.position = new Vector3(-3.2f, -0.7f, -5);
            transform.eulerAngles = new Vector3(0, 150, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    PlayerMove playerMove;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (playerMove.animationType == 0)
        {
            animator.SetBool("isJog", false);
            animator.SetBool("isDash", false);
        }
        else if (playerMove.animationType == 1)
        {
            animator.SetBool("isJog", true);
            animator.SetBool("isDash", false);
        }
        else if (playerMove.animationType == 2)
        {
            animator.SetBool("isDash", true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Animation : MonoBehaviour
{
    Animator animator;
    PlayerMove2 playerMove;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove2>();
    }

    void Update()
    {
        if (playerMove.IsFalling())
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
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
}
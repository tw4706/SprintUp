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
        if (playerMove.isMoveAnim)
        {
            animator.SetBool("IsJogging", true);
        }
        else
        {
            animator.SetBool("IsJogging", false);
        }
    }
}

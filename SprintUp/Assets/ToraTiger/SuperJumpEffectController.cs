using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpEffectController : MonoBehaviour
{
    float aliveTime = 0.0f;

    void Update()
    {
        // oŒ»‚µ‚Ä‚©‚ç1.5•bŒã‚ÉÁ‚¦‚é
        aliveTime += Time.deltaTime;
        if (aliveTime > 1.5f)
        {
            Destroy(gameObject);
        }
    }
}

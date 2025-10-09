using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    public Transform target; // ’‹“_
    public float rotationSpeed = 10f;

    void Update()
    {
        // Y²‚ğ’†S‚É‰ñ“]
        transform.RotateAround(target.position, 
            Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

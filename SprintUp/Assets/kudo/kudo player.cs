using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class kudoplayer : MonoBehaviour
{
    float Speed = 3.0f;

    // Start is called before the first frame update
    
      

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Speed * transform.forward * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= Speed * transform.forward * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Speed * transform.right * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= Speed * transform.right * Time.deltaTime;
            }

        }
    }


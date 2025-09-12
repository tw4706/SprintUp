using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class kamera : MonoBehaviour
{
    public Transform player;//プレイヤーのtransform
    public float distance = 5.0f;//カメラ距離
    public float sensitivity = 100.0f;
    public float verticalAnglemin = -30.0f;
    public float verticalAnglemax = 60.0f;

    private float yaw = 0.0f;//水平角度(Y軸)
    private float pitch = 20.0f;//垂直角度(X軸)




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //右スティックの入力取得
        float rightStickX = UnityEngine.Input.GetAxis("RightStickHorizontal");
        float rightStickY = UnityEngine.Input.GetAxis("RightStickVertical");

        //スティックの入力に応じて角度を変更
        yaw += rightStickX * sensitivity * Time.deltaTime;
        pitch-= rightStickY * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch,verticalAnglemin, verticalAnglemax);

        //カメラの回転を計算
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 position = player.position - rotation * Vector3.forward * distance;

        //カメラを配置し、プレイヤーを見る
        transform.position = position;
        transform.LookAt(player);
    }
}

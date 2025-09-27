using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class kamera_1: MonoBehaviour
{
    public Transform player;//プレイヤーのtransform
    public float distance = 10.0f;//カメラ距離
    public float sensitivity = 50.0f;//感度
    public float verticalAnglemin = -89.0f;//垂直角度の最小値
    public float verticalAnglemax = 89.0f;//垂直角度の最大値

    private float yaw = 0.0f;//水平角度(Y軸)
    private float pitch = 20.0f;//垂直角度(X軸)

    public float headHeightOffset = 2.0f;//プレイヤーの頭の高さ


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //右スティックの入力取得
        float rightStickX = UnityEngine.Input.GetAxis("RightStickHorizontal_1");
        float rightStickY = UnityEngine.Input.GetAxis("RightStickVertical_1");
        Debug.Log($"Right Stick X: {rightStickX}, Y: {rightStickY}"); // ← これ追加してみて
        //デッドゾーン
        if (Mathf.Abs(rightStickX) < 0.35f) rightStickX = 0f;
        if (Mathf.Abs(rightStickY) < 0.35f) rightStickY = 0f;

        Debug.Log($"Right Stick X: {rightStickX}, Y: {rightStickY}"); // ← これ追加してみて
        //スティックの入力に応じて角度を変更
        yaw += rightStickX * sensitivity * Time.deltaTime;
        pitch+= rightStickY * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch,verticalAnglemin, verticalAnglemax);

        //カメラの回転を計算
        //Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        //Vector3 position = player.position - rotation * Vector3.forward * distance;
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        //カメラを配置し、プレイヤーを見る
        Vector3 targetPosition = player.position + new Vector3(0, headHeightOffset, 0);
        transform.position = targetPosition + offset; 
        transform.LookAt(player);
    }
}

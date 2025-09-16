using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class kamera : MonoBehaviour
{
    public Transform player;//�v���C���[��transform
    public float distance = 10.0f;//�J��������
    public float sensitivity = 100.0f;//���x
    public float verticalAnglemin = -89.0f;//�����p�x�̍ŏ��l
    public float verticalAnglemax = 89.0f;//�����p�x�̍ő�l

    private float yaw = 0.0f;//�����p�x(Y��)
    private float pitch = 20.0f;//�����p�x(X��)




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //�E�X�e�B�b�N�̓��͎擾
        float rightStickX = UnityEngine.Input.GetAxis("RightStickHorizontal");
        float rightStickY = UnityEngine.Input.GetAxis("RightStickVertical");
        Debug.Log($"Right Stick X: {rightStickX}, Y: {rightStickY}"); // �� ����ǉ����Ă݂�
        //�X�e�B�b�N�̓��͂ɉ����Ċp�x��ύX
        yaw += rightStickX * sensitivity * Time.deltaTime;
        pitch+= rightStickY * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch,verticalAnglemin, verticalAnglemax);

        //�J�����̉�]���v�Z
        //Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        //Vector3 position = player.position - rotation * Vector3.forward * distance;
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        //�J������z�u���A�v���C���[������
        transform.position = player.position+offset;
        transform.LookAt(player);
    }
}

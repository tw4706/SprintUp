using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class kamera_1: MonoBehaviour
{
    public Transform player;//�v���C���[��transform
    public float distance = 10.0f;//�J��������
    public float sensitivity = 50.0f;//���x
    public float verticalAnglemin = -89.0f;//�����p�x�̍ŏ��l
    public float verticalAnglemax = 89.0f;//�����p�x�̍ő�l

    private float yaw = 0.0f;//�����p�x(Y��)
    private float pitch = 20.0f;//�����p�x(X��)

    public float headHeightOffset = 2.0f;//�v���C���[�̓��̍���


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //�E�X�e�B�b�N�̓��͎擾
        float rightStickX = UnityEngine.Input.GetAxis("RightStickHorizontal_1");
        float rightStickY = UnityEngine.Input.GetAxis("RightStickVertical_1");
        Debug.Log($"Right Stick X: {rightStickX}, Y: {rightStickY}"); // �� ����ǉ����Ă݂�
        //�f�b�h�]�[��
        if (Mathf.Abs(rightStickX) < 0.35f) rightStickX = 0f;
        if (Mathf.Abs(rightStickY) < 0.35f) rightStickY = 0f;

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
        Vector3 targetPosition = player.position + new Vector3(0, headHeightOffset, 0);
        transform.position = targetPosition + offset; 
        transform.LookAt(player);
    }
}

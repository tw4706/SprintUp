using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkOnSelect : MonoBehaviour
{
    public Graphic targetUI;// �_�ł�����UI
    public float blinkSpeed = 0.5f; // �_�ł̊Ԋu
    public Color blinkColor = Color.white;
    bool isSelected = false;// �I������Ă��邩�ǂ���
    float blinkTimer = 0f;// �_�ł̃^�C�}�[
    void Start()
    {
    }

    // Update is called once per frame

void Update()
    {
        // �Q�[���p�b�h����ł��I����Ԃ��ێ������
        isSelected = EventSystem.current.currentSelectedGameObject == gameObject;

        if (isSelected && targetUI != null)
        {
            blinkTimer += Time.unscaledDeltaTime * blinkSpeed;
            float alpha = Mathf.Lerp(0.3f, 1f, Mathf.Abs(Mathf.Sin(blinkTimer)));
            Color color = blinkColor;
            color.a = alpha;
            targetUI.color = color;
        }
        else if (targetUI != null)
        {
            Color color = targetUI.color;
            color.a = 0f; // ��I�����͓���
            targetUI.color = color;
            blinkTimer = 0f;
        }
    }
    // �I�����ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
    }
    // �I���O�ŌĂ΂�郁�\�b�h
    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }


}

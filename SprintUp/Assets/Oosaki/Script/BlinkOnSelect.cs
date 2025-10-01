using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkOnSelect : MonoBehaviour
{
    public Graphic targetUI;// 点滅させるUI
    public float blinkSpeed = 0.5f; // 点滅の間隔
    public Color blinkColor = Color.white;
    bool isSelected = false;// 選択されているかどうか
    float blinkTimer = 0f;// 点滅のタイマー
    void Start()
    {
    }

    // Update is called once per frame

void Update()
    {
        // ゲームパッド操作でも選択状態が維持される
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
            color.a = 0f; // 非選択時は透明
            targetUI.color = color;
            blinkTimer = 0f;
        }
    }
    // 選択されたときに呼ばれるメソッド
    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
    }
    // 選択外で呼ばれるメソッド
    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }


}

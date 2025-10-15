using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GamePadSelected : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || // A
            Input.GetKeyDown(KeyCode.JoystickButton1) || // B
            Input.GetKeyDown(KeyCode.JoystickButton2) || // X
            Input.GetKeyDown(KeyCode.JoystickButton3))   // Y
        {
            GameObject selected = EventSystem.current.currentSelectedGameObject;
            if (selected != null)
            {
                Button btn = selected.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.Invoke(); // É{É^ÉìÇÃOnClickÇé¿çs
                }
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButtonTransition : MonoBehaviour
{

    public GameObject firstButton;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

}

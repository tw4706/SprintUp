using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButtonController : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public string nextSceneName = "GameScene";

    bool hasPressed = false;

    void Update()
    {
        if (hasPressed) return;
    }

    void TriggerSceneChange()
    {
        hasPressed = true;
        sceneChanger.ChangeScene(nextSceneName);
    }

}

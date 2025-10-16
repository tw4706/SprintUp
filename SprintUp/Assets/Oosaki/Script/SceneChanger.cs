using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneChanger : MonoBehaviour
{
    public FadeManager fadeManager;

    public void OnClickChangeScene(string sceneName)
    {
        fadeManager.ChangeScene(sceneName);
    }
}

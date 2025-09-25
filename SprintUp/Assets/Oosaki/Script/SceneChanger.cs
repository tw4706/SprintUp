using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    public void OnClick(string sceneName)
    {
        if (FadeManager.Instance != null)
        {
            FadeManager.Instance.FadeToScene(sceneName);
        }
        else
        {
            Debug.Log("FadeManager‚ªŒ©‚Â‚©‚ç‚È‚¢I");
        }
    }
}

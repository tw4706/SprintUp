using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    public void OnClick()
    {
        FadeManager fade=GetComponent<FadeManager>();
        if(fade!=null)
        {
            fade.FadeToScene("GameScene"
                );
        }
        else
        {
            Debug.Log("å©Ç¬Ç©ÇËÇ‹ÇπÇÒÅI");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInitializer : MonoBehaviour
{
    public GameObject fadePrefab;
    void Awake()
    {
        if(FindObjectOfType<FadeManager>()==null)
        {
            GameObject fade= Instantiate(fadePrefab);
            DontDestroyOnLoad(fade);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

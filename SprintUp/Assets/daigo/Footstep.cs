using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class Footstep : MonoBehaviour
{
    [Header("地面タグごとの足音")]
    public AudioClip grassSound;
    public AudioClip woodSound;
    public AudioClip stoneSound;
    public AudioClip defaultSound;

    [Header("足音の再生間隔（秒）")]
    public float stepInterval = 0.5f;

    //private float stepTimer;
    private AudioSource audioSource;
    private CharacterController controller;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //stepTimer = 0f;
    }

    void Update()
    {
        PlayFootstepSound();
    }

    void PlayFootstepSound()
    {
        string groundTag = DetectGroundTag();

        AudioClip clipToPlay = defaultSound;

        switch (groundTag)
        {
            case "Grass":
                clipToPlay = grassSound;
                break;
            case "Wood":
                clipToPlay = woodSound;
                break;
            case "Stone":
                clipToPlay = stoneSound;
                break;
        }

        if (clipToPlay != null)
        {
            audioSource.PlayOneShot(clipToPlay, 1.0f);
        }
        else
        {
            Debug.LogWarning($"足音クリップが設定されていません（Tag: {groundTag}）");
        }
    }

    string DetectGroundTag()
    {
        // プレイヤーの少し上から下向きにRayを飛ばす
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 2.0f))
        {
            return hit.collider.tag;
        }

        return "Untagged"; // 当たらなければデフォルト
    }
}

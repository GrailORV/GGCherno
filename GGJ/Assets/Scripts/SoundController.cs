using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public enum SOUNDS
    {
        SOUND_0 = 0,
    }

    public enum BGM
    {
        BGM_0 = 0,
    }

    [SerializeField]
    private AudioClip[] sounds;
    [SerializeField]
    private AudioClip[] bgm;

    public static SoundController instance;

    private AudioSource audio;

    void Awake () {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        audio = GetComponent<AudioSource>();
        enabled = true;
    }
    
    public void Play(SOUNDS s)
    {
        if (!enabled) return;
        AudioSource.PlayClipAtPoint(sounds[(int)s], transform.position, 1.0f);
    }

    public void Play(BGM b)
    {
        if (!enabled) return;
        audio.Stop();
        audio.clip = bgm[(int)b];
        audio.Play();
    }

    public void StopBGM(BGM b)
    {
        audio.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoController : MonoBehaviour {
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(768, 1024, false, 60);
    }


    [SerializeField]
    Fade fade;

    float time;

    void Start()
    {
        time = 0;   
    }


    void Update()
    {
        time += Time.deltaTime;
        if (fade.Status != Fade.FADE_STATUS.FADE_NONE)
        {
            return;
        }

        if (time >= 2)
        {
            fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Title");
        }
    }
}

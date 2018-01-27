using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    [SerializeField]
    private Scene nextScene;

    [SerializeField]
    private Image fade;

    public enum FADE_STATUS
    {
        FADE_NONE,
        FADE_IN,
        FADE_IN_START,
        FADE_OUT,
        FADE_OUT_START,
        FADE_MAX
    };

    private string nextSceneName;
    private FADE_STATUS mystatus;
    private float fadetime;
    private float currentTime;

    // Use this for initialization
    void Start()
    {
        fadetime = 60.0f;
        currentTime = 0;
        mystatus = FADE_STATUS.FADE_NONE;
        if (nextScene != null)
        {
            nextSceneName = nextScene.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mystatus == FADE_STATUS.FADE_NONE)
        {
            return;
        }

        if (mystatus == FADE_STATUS.FADE_IN_START)
        {
            


        }
    }

    public void Start(FADE_STATUS status, float time, string nextScene = null)
    {

    }
}

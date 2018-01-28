using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Image fade;

    [SerializeField]
    private float sceneStartFadeTime;

    public enum FADE_STATUS
    {
        FADE_NONE,
        FADE_IN,
        FADE_OUT,
        FADE_MAX
    };

    private FADE_STATUS mystatus;
    public FADE_STATUS Status
    {
        set { this.mystatus = value; }
        get { return this.mystatus; }
    }

    private string nextSceneName;
    
    private float fadetime;
    private float currentTime;

    // Use this for initialization
    void Start()
    {
        nextSceneName = null;
        Start(FADE_STATUS.FADE_IN, sceneStartFadeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (mystatus == FADE_STATUS.FADE_NONE)
        {
            return;
        }

        if (mystatus == FADE_STATUS.FADE_IN || mystatus == FADE_STATUS.FADE_OUT)
        {
            currentTime += Time.deltaTime;
            if (currentTime > fadetime)
            {
                mystatus = FADE_STATUS.FADE_NONE;
                if (nextSceneName != null)
                {
                    SceneManager.LoadScene(nextSceneName);
                }
            }

        }
    }

    public void Start(FADE_STATUS status, float time, string nextScene = null)
    {
        if (nextScene != null)
        {
            bool sceneIsValid = Enumerable.Range(0, SceneManager.sceneCountInBuildSettings)
            .Select(c => SceneUtility.GetScenePathByBuildIndex(c))
            .Select(c => Path.GetFileNameWithoutExtension(c))
            .Any(c => c == nextScene);
            if (sceneIsValid == false)
            {
                return;
            }
        }


        if (status == FADE_STATUS.FADE_IN)
        {
            mystatus = status;
            fadetime = time;
            currentTime = 0;
            nextSceneName = nextScene;
            fade.CrossFadeAlpha(0.0f, time, false);
        }

        if (status == FADE_STATUS.FADE_OUT)
        {
            mystatus = status;
            fadetime = time;
            currentTime = 0;
            nextSceneName = nextScene;
            Color colorbuff = fade.color;
            colorbuff.a = 0.0f;
            fade.CrossFadeAlpha(1.0f, time, false);
        }
    }
}

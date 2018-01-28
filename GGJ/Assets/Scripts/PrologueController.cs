using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueController : MonoBehaviour
{
    [SerializeField]
    Fade fade;

    [SerializeField]
    Text storyField;

    [SerializeField]
    private TextAsset storyTextFile;

    [SerializeField]
    private Button[] button;

    [SerializeField]
    private Canvas skipLog;

    private int selector;
    private bool operate;
    private bool pushEnabled;
    private int section;
    private string[] prologueTextList;

    // Use this for initialization
    void Start()
    {
        selector = 0;
        operate = false;
        button[selector].Select();
        pushEnabled = false;
        LoadPrologueText();
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().Play(SoundController.BGM.BGM_STORY);
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().SetVolume(0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade.Status == Fade.FADE_STATUS.FADE_IN && fade.Status == Fade.FADE_STATUS.FADE_OUT)
        {
            return;
        }

        if (Input.GetAxis("SelectRight") > 0.8f && !operate)
        {
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().Play(SoundController.SOUNDS.SOUND_TITLESELECT);
            selector++;
            if (selector >= button.Length)
            {
                selector = 0;
            }
            button[selector].Select();
            operate = true;
        }
        if (Input.GetAxis("SelectRight") < -0.8f && !operate)
        {
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().Play(SoundController.SOUNDS.SOUND_TITLESELECT);
            selector--;
            if (selector < 0)
            {
                selector = button.Length - 1;
            }
            button[selector].Select();
            operate = true;
        }

        if (Input.GetAxis("SelectRight") < 0.2f && Input.GetAxis("SelectRight") > -0.2f && operate)
        {
            operate = false;
        }

        if (fade.Status == Fade.FADE_STATUS.FADE_WAIT)
        {
            return;
        }

        if (section < prologueTextList.Length)
        {
            storyField.text = prologueTextList[section];
        }
        else
        {
            storyField.text = "";
        }

        if (Input.GetAxis("Submit") > 0.9f && pushEnabled)
        {
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().Play(SoundController.SOUNDS.SOUND_TITLETEXT);
            pushEnabled = false;
            section++;
            if (section >= prologueTextList.Length)
            {
                fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Game");
            }
        }
        else if (Input.GetAxis("Submit") < 0.2f && !pushEnabled)
        {
            pushEnabled = true;
        }


        if (Input.GetAxis("Cancel") > 0.9f)
        {
            fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Game");
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().Play(SoundController.SOUNDS.SOUND_SELECT);
        }

        if (Input.GetAxis("Options") > 0.9f)
        {
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().Play(SoundController.SOUNDS.SOUND_SELECT);
            fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Title");
        }
    }

    public void SkipStory()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReadStory()
    {
        fade.Start(Fade.FADE_STATUS.FADE_IN, 1.0f);
        skipLog.gameObject.SetActive(false);
        foreach(var b in button)
        {
            b.interactable = false;
        }
    }

    private void LoadPrologueText()
    {
        storyField.text = "";
        section = 0;
        string storyBuff = storyTextFile.text;
        prologueTextList = storyBuff.Split(new string[] { "sec:" }, System.StringSplitOptions.RemoveEmptyEntries);
    }

}

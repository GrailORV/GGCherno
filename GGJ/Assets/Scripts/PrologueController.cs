using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueController : MonoBehaviour
{
    [SerializeField]
    Fade fade;

    [SerializeField]
    Text storyField;

    [SerializeField]
    private TextAsset storyTextFile;

    List<string> prologueTextList;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fade.Status != Fade.FADE_STATUS.FADE_NONE)
        {
            return;
        }

        if (Input.GetAxis("Cancel") > 0.9f)
        {
            fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Game");
        }
    }

    void LoadPrologueText()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    Fade fade;

    private int selector;
    private bool operate;

    [SerializeField]
    private Button[] button;

    // Use this for initialization
    void Start()
    {
        operate = false;
        selector = 0;
        button[selector].Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade.Status != Fade.FADE_STATUS.FADE_NONE)
        {
            return;
        }

        ChooseOption();
    }

    public void LoadGame()
    {
        if (fade.Status != Fade.FADE_STATUS.FADE_NONE)
        {
            return;
        }

        fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Prologue");
    }

    private void ChooseOption()
    {
        if (Input.GetAxis("SelectRight") > 0.8f && !operate)
        {
            button[selector].gameObject.SetActive(false);
            selector++;
            if (selector >= button.Length)
            {
                selector = 0;
            }
            button[selector].gameObject.SetActive(true);
            button[selector].Select();
            operate = true;
        }
        if (Input.GetAxis("SelectRight") < -0.8f && !operate)
        {
            button[selector].gameObject.SetActive(false);
            selector--;
            if (selector < 0)
            {
                selector = button.Length - 1;
            }
            button[selector].gameObject.SetActive(true);
            button[selector].Select();
            operate = true;
        }

        if (Input.GetAxis("SelectRight") < 0.2f && Input.GetAxis("SelectRight") > -0.2f && operate)
        {
            operate = false;
        }
    }

}

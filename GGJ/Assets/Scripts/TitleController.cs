using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    Fade fade;

    private int selector;
    private bool operate;

    [SerializeField]
    private Button[] button;

    [SerializeField]
    private Image[] titleLogo;

    [SerializeField]
    private int titleAnimLeft, titleAnimRight, titleAnimBottom;

    [SerializeField]
    private float scaleAnimTime;

    private Vector3 titleLeftPosStart, titleRightPosStart, titleBottomPosStart;
    private Vector3 titleLeftPosEnd, titleRightPosEnd, titleBottomPosEnd;
    private int animNum = 0;
    private float count = 0.0f;

    // Use this for initialization
    void Start()
    {
        animNum = 0;
        count = 0.0f;
        titleLeftPosStart = titleLeftPosEnd = titleLogo[0].transform.position;
        titleRightPosStart = titleRightPosEnd = titleLogo[1].transform.position;
        titleBottomPosStart = titleBottomPosEnd = titleLogo[2].transform.position;

        titleLeftPosStart.x -= titleAnimLeft;
        titleRightPosStart.x += titleAnimRight;
        titleBottomPosStart.y -= titleAnimBottom;

        titleLogo[0].transform.position = titleLeftPosStart;
        titleLogo[1].transform.position = titleRightPosStart;
        titleLogo[2].transform.position = titleBottomPosStart;
        titleLogo[3].transform.localScale = Vector3.zero;

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

        if (animNum < titleLogo.Length)
        {
            count += Time.deltaTime;
            if (count > scaleAnimTime)
            {
                count = 0.0f;
                animNum++;
            }
            switch (animNum)
            {
                case 0:
                    titleLogo[0].transform.position = Vector3.Lerp(titleLeftPosStart, titleLeftPosEnd, count / scaleAnimTime);
                    break;
                case 1:
                    titleLogo[1].transform.position = Vector3.Lerp(titleRightPosStart, titleRightPosEnd, count / scaleAnimTime);
                    break;
                case 2:
                    titleLogo[2].transform.position = Vector3.Lerp(titleBottomPosStart, titleBottomPosEnd, count / scaleAnimTime);
                    break;
                case 3:
                    titleLogo[3].transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, count / scaleAnimTime);
                    break;
                default:
                    break;
            }
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

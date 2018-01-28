using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    [SerializeField]
    private Sprite[] ranks;
    [SerializeField]
    private Sprite[] Numbers;

    [SerializeField]
    private Image[] scoreNumbers;
    [SerializeField]
    private Image rankView;
    [SerializeField]
    Fade fade;

    void Start () {
        GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>().Play(SoundController.BGM.BGM_SCORE);
        int score = PlayerPrefs.GetInt("Score");

        scoreNumbers[6].sprite = Numbers[score % 10000000 / 1000000];
        scoreNumbers[5].sprite = Numbers[score % 1000000 / 100000];
        scoreNumbers[4].sprite = Numbers[score % 100000 / 10000];
        scoreNumbers[3].sprite = Numbers[score % 10000 / 1000];
        scoreNumbers[2].sprite = Numbers[score % 1000 / 100];
        scoreNumbers[1].sprite = Numbers[score % 100 / 10];
        scoreNumbers[0].sprite = Numbers[score % 10 / 1];

        if (score >= 100000)
            rankView.sprite = ranks[0];
        else if (score >= 10000)
            rankView.sprite = ranks[1];
        else if (score >= 1000)
            rankView.sprite = ranks[2];
        else 
            rankView.sprite = ranks[3];
    }
	
	
	void Update () {
        if (fade.Status != Fade.FADE_STATUS.FADE_NONE)
        {
            return;
        }

        if (Input.GetAxis("Submit") > 0.1f)
        {
            fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Epilogue");
        }
	}
}

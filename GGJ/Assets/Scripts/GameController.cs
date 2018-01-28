using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    
    [SerializeField]
    private Sprite loopTexture;
    GameObject[] bgLoop;

    public float velGame;
    public int score;
    private const int lifeMax = 3;
    public int life;
    public int combo;
    [SerializeField]
    private Sprite[] Numbers;

    [SerializeField]
    private Image[] scoreNumbers;
    [SerializeField]
    private Image[] lifeCount;
    [SerializeField]
    private Image[] comboNumbers;

    SoundController soundCon;

    // Use this for initialization
    void Awake () {
        bgLoop = new GameObject[2];
        Vector2 initPos = new Vector2(0,0);
        for (int i = 0; i < 2; i++)
        {
            bgLoop[i] = new GameObject("BGLoop");
            bgLoop[i].transform.position = initPos;
            bgLoop[i].AddComponent<SpriteRenderer>().sprite = loopTexture;
            bgLoop[i].transform.localScale = new Vector2(2.5f,2.5f);
            bgLoop[i].AddComponent<BoxCollider2D>().isTrigger = true;
            initPos = bgLoop[i].transform.position + new Vector3(0, bgLoop[i].GetComponent<BoxCollider2D>().bounds.size.y,0);
        }
    }

    private void Start()
    {
        velGame = 0.08f;
        score = 0;
        life = lifeMax;
        combo = 0;
        soundCon = GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>();
        soundCon.Play(SoundController.BGM.BGM_BATTLE);
        soundCon.SetVolume(1.0f);
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < 2; i++)
        {
            bgLoop[i].transform.position -= new Vector3(0,velGame,0);
            if(bgLoop[i].transform.position.y + bgLoop[i].GetComponent<BoxCollider2D>().bounds.size.y/2 < transform.position.y - GetComponent<BoxCollider2D>().bounds.size.y / 2)
            {
                bgLoop[i].transform.position += new Vector3(0, bgLoop[i].GetComponent<BoxCollider2D>().bounds.size.y*2, 0);
            }
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreNumbers[6].sprite = Numbers[score % 10000000 / 1000000];
        scoreNumbers[5].sprite = Numbers[score % 1000000 / 100000];
        scoreNumbers[4].sprite = Numbers[score % 100000 / 10000];
        scoreNumbers[3].sprite = Numbers[score % 10000 / 1000];
        scoreNumbers[2].sprite = Numbers[score % 1000 / 100];
        scoreNumbers[1].sprite = Numbers[score % 100 / 10];
        scoreNumbers[0].sprite = Numbers[score % 10 / 1];

        comboNumbers[2].sprite = Numbers[combo % 1000 / 100];
        comboNumbers[1].sprite = Numbers[combo % 100 / 10];
        comboNumbers[0].sprite = Numbers[combo % 10 / 1];
    }

    public void AddLife()
    {
        if (life != lifeMax)
        {
            life++;
            lifeCount[life - 1].gameObject.SetActive(true);
        } 
    }

    public void SubstractLife()
    {
        lifeCount[life - 1].gameObject.SetActive(false);
        life--;
        if (life <= 0)
        {
            
        }
    }

    void SceneScore()
    {
        SceneManager.LoadScene("Score");
        soundCon.StopBGM();
        PlayerPrefs.SetInt("Score", score);
    }
}

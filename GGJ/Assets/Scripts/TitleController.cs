using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{

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
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundController>().Play(SoundController.BGM.BGM_0);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundController>().Play(SoundController.SOUNDS.SOUND_0);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseOption();
 
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
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

    private void DecideOption()
    {

    }
}

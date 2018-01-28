using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueController : MonoBehaviour
{

    [SerializeField]
    Fade fade;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Cancel") > 0.8f)
        {
            fade.Start(Fade.FADE_STATUS.FADE_OUT, 1.0f, "Game");
        }
    }

}

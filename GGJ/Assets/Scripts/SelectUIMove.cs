using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUIMove : MonoBehaviour {

    [SerializeField]
    private int height = 0;

    [SerializeField]
    private float slerpTime = 1.0f;

    private Vector3 bottomPos;
    private Vector3 topPos;
    private float count = 0.0f;
    private bool up = true;

    // Use this for initialization
    void Start()
    {
        count = 0.0f;
        bottomPos = transform.position;
        topPos = transform.position;
        topPos.y += height;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > slerpTime)
        {
            count = 0.0f;
            up = !up;
        }
        if (up)
        {
            transform.position = Vector3.Slerp(bottomPos, topPos, count / slerpTime);
        }
        else
        {
            transform.position = Vector3.Slerp(topPos, bottomPos, count / slerpTime);
        }
    }
}

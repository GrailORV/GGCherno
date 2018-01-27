using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public bool stop;
    public Vector2 targetPos;
    private float factor;
    private Vector2 initPos;
    private float distance;
    private float speed;

    void Start () {
        factor = 1.1f;
        speed = 2.0f;
        stop = true;
    }
	
	void Update () {
        if (factor > 1.0f)
        {
            if (!stop)
            {
                initPos = transform.position;
                if(transform.rotation.z == 0)
                    targetPos.y = -targetPos.y;
                else
                    targetPos.x = -targetPos.x;
                distance = Vector2.Distance(initPos, targetPos);
                factor = 0.0f;
            }
        }
        else
        {
            factor += (speed * Time.deltaTime) / distance;
            transform.position = Vector2.Lerp(initPos, targetPos, factor);
        }
    }

    public void StopMoveWall(Vector2 tpos)
    {
        stop = !stop;
        targetPos = tpos;
        factor = 1.1f;
    }
}

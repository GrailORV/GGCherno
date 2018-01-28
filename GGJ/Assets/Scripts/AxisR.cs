﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisR : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    bool suelta;
    const int cantBullet = 6;
    GameObject[] bullets;

    [SerializeField]
    private GameObject cannonDirecction;

    // Use this for initialization
    void Start () {
        suelta = true;
        bullets = new GameObject[cantBullet];
        for(int i = 0; i < cantBullet; i++)
        {
            bullets[i] = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            bullets[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("VerticalR") < -0.2F && suelta)
        {
            int i = 0;
            while (i < cantBullet)
            {
                if (!bullets[i].activeSelf)
                {
                    bullets[i].SetActive(true);
                    bullets[i].transform.position = gameObject.transform.position + new Vector3(0, 0, 1);
                    float tita = Mathf.Atan2(Input.GetAxis("HorizontalR"), -Input.GetAxis("VerticalR")) * 180 / Mathf.PI;
                    bullets[i].transform.rotation = Quaternion.Euler(0, 0, tita);
                    bullets[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(-Input.GetAxis("HorizontalR"), -Input.GetAxis("VerticalR")) * 50.0f, ForceMode2D.Impulse);
                    suelta = false;
                    cannonDirecction.transform.localRotation = Quaternion.Euler(0, -tita, 0);
                    break;
                }
                else i++;
            }   
        }
        else if (Input.GetAxis("VerticalR") >= -0.2f)
            suelta = true;
    }
}

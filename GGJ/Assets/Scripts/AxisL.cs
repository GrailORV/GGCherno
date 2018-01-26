using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisL : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

    bool suelta;
    const int cantBullet = 15;
    GameObject[] bullets;

    // Use this for initialization
    void Start()
    {
        suelta = true;
        bullets = new GameObject[cantBullet];
        for (int i = 0; i < cantBullet; i++)
        {
            bullets[i] = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            bullets[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("VerticalL") < -0.2F && suelta)
        {
            int i = 0;
            while (i < cantBullet)
            {
                if (!bullets[i].activeSelf)
                {
                    bullets[i].SetActive(true);
                    bullets[i].transform.position = gameObject.transform.position;
                    bullets[i].transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("HorizontalL") * 90);
                    bullets[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(-Input.GetAxis("HorizontalL"), -Input.GetAxis("VerticalL")) * 50.0f, ForceMode2D.Impulse);
                    suelta = false;
                    break;
                }
                else i++;
            }
        }
        else if (Input.GetAxis("VerticalL") > -0.2F && Input.GetAxis("VerticalL") < 0)
            suelta = true;
    }
}

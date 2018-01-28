using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour {


    [SerializeField]
    private int BossLife;

    private const string BULLET_TAG = "Bullet";
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddLife(int addLife)
    {
        BossLife += addLife;

        if(BossLife<=0)
        {
            BossLife = 0;

            //終了処理
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //弾とのあたり判定
        if (collider.gameObject.tag == BULLET_TAG)
        {
            collider.gameObject.SetActive(false);
        }
    }
}

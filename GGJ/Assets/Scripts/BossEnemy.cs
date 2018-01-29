using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{


    [SerializeField]
    private int BossMAXLife;

    [SerializeField]
    private int DamageFromBullet;

    [SerializeField]
    private int DamageFromExplosion;

    [SerializeField]
    private int AttackInterval_1;
    [SerializeField]
    private int AttackInterval_2;

    [SerializeField]
    private int AttackEnemyMAX_1;
    [SerializeField]
    private int AttackEnemyMAX_2;

    public GameObject BossWeakPoint;

    private const string BULLET_TAG = "Bullet";

    private const int INVINCIBLE_TIME = 120;

    private int BossLife;

    private int invincibleTimeCnt;

    private bool invincibleFlag;

    private int AttackCount;

    int UseEnemyNum;

    // Use this for initialization
    void Start()
    {
        invincibleFlag = false;

        invincibleTimeCnt = 0;

        AttackCount = 0;

        BossLife = BossMAXLife;

        UseEnemyNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleFlag)
        {
            invincibleTimeCnt++;
            if(invincibleTimeCnt>INVINCIBLE_TIME)
            {
                invincibleTimeCnt = 0;
                invincibleFlag = false;
            }
        }

        AttackCount++;
        if(AttackCount > AttackInterval_1 && UseEnemyNum == 1)
        {
            StartCoroutine("processCreateEnemy");
        }
        if (AttackCount > AttackInterval_2 && UseEnemyNum == 2)
        {
            StartCoroutine("processCreateEnemy");
        }
    }

    public void AddLife(int addLife)
    {
        BossLife += addLife;

        if (BossLife <= 0)
        {
            BossLife = 0;

            //終了処理
            SceneManager.LoadScene("Score");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //弾とのあたり判定
        if (collider.gameObject.tag == BULLET_TAG && !invincibleFlag)
        {
            collider.gameObject.SetActive(false);

            BossLife -= DamageFromBullet;
        }
    }

    public void SetDamageFromExplosion()
    {
        BossLife -= DamageFromExplosion;

        invincibleFlag = true;
    }

    private IEnumerator processCreateEnemy()
    {
        int forMAX = 1;

        if (UseEnemyNum == 1)
            forMAX = AttackEnemyMAX_1;
        if (UseEnemyNum == 2)
            forMAX = AttackEnemyMAX_2;

        for (int nCnt=0;nCnt<forMAX;nCnt++)
        {
            yield return new WaitForSeconds(0.1f);
        }

        if (UseEnemyNum == 1)
            UseEnemyNum = 2;
        else if (UseEnemyNum == 2)
            UseEnemyNum = 2;

    }
}

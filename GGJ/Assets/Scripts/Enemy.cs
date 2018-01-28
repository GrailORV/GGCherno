using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int enemyGroupNumber;

    [SerializeField]
    private bool isBulletEnable;

    [SerializeField]
    private float explosionScale;

    [SerializeField]
    private GameObject ExplosionParticle;

    private const string BULLET_TAG = "Bullet";

    private const string ENEMY_TAG = "Enemy";

    private const float TIME_FROM_EXPLOSION_TO_CHAIN = 0.2f;

    private const float TIME_FROM_EXPLOSION_TO_DEATH = 1.0f;

    private const int SURVIVAL_HOURS_WITHOUT_SCREEN = 300;

    private bool bombedFlag;

    private bool chainExplosion;

    private GameObject ExplosionParticlePtr;

    private int countOutOfScreen;

    // Use this for initialization
    void Start () {
        bombedFlag = false;
        chainExplosion = false;
        countOutOfScreen = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //DecisionOutOfScreen();
    }

    // void OnCollisionEnter2D(Collision2D collision)
    void OnTriggerEnter2D(Collider2D collider)
    {
        //弾とのあたり判定
        if(collider.gameObject.tag== BULLET_TAG && isBulletEnable)
        {
            //bombedFlag = true;
            chainExplosion = true;

            float radius = this.GetComponent<CircleCollider2D>().radius;

            this.GetComponent<CircleCollider2D>().radius = radius * explosionScale;

            StartCoroutine("processAfterBombed");
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //誘爆の処理
        if (collider.gameObject.tag == ENEMY_TAG && bombedFlag)
        {
            collider.GetComponent<Enemy>().SetBombedParam();
        }
    }

    private void SetBombedParam()
    {
        if (chainExplosion)
            return;

        chainExplosion = true;

        this.GetComponent<CircleCollider2D>().radius = 0.5f * explosionScale;

        StartCoroutine("processAfterBombed");
    }

    private void DecisionOutOfScreen()
    {
        if(!gameObject.GetComponent<Renderer>().isVisible)
        {
            countOutOfScreen++;

            if(countOutOfScreen > SURVIVAL_HOURS_WITHOUT_SCREEN)
            {
                SetCountEnemyController();

                this.gameObject.SetActive(false);
            }
        }
        else
        {
            countOutOfScreen = 0;
        }
    }

    private IEnumerator processAfterBombed()
    {
        this.gameObject.SetActive(false);
        ExplosionParticlePtr = Instantiate(ExplosionParticle, this.gameObject.transform.position, Quaternion.Euler(180,0,0));
        Destroy(ExplosionParticlePtr, ExplosionParticlePtr.GetComponent<ParticleSystem>().main.duration);
        yield return new WaitForSeconds(TIME_FROM_EXPLOSION_TO_CHAIN);

        bombedFlag = true;

        //yield return new WaitForSeconds(TIME_FROM_EXPLOSION_TO_DEATH);

        //SetCountEnemyController();

        //Destroy(ExplosionParticlePtr);

        //Destroy(this.gameObject);

        //this.gameObject.SetActive(false);
    }

    void SetCountEnemyController()
    {
        //Enemycontroller.SubActiveEnemyCount();
    }
}

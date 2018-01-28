using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour {

    [SerializeField]
    private GameObject prefEnemy;
    const int countEnemy = 12;
    GameObject[] Enemies;
    int timeSpawnEnemy;
    int timerSpawn;
    int nowPattern;
    int ContSpawns;
    int pauseTimer;
    float realTime;
    [SerializeField]
    private GameObject wall;
    private GameObject[] walls;
    SoundController soundCon;

    bool bossState;

    void Start()
    {
        Enemies = new GameObject[countEnemy];
        for(int i = 0; i < countEnemy; i++)
        {
            Enemies[i] = Instantiate(prefEnemy, new Vector3(0, 6, -1), Quaternion.identity);
        }
        ContSpawns = 0;
        nowPattern = Random.Range(1, 9);
        timeSpawnEnemy = 20;
        timerSpawn = 0;
        pauseTimer = 300;
        realTime = 0;
        soundCon = GameObject.FindGameObjectWithTag("AudioController").GetComponent<SoundController>();
        bossState = false;
        walls = new GameObject[3];
    }

    private void Update()
    {
        realTime += Time.deltaTime;
        if(realTime >= 180 && !bossState)
        {
            soundCon.Play(SoundController.BGM.BGM_BOSS);
            walls[0] = Instantiate(wall, new Vector2(-2.5f, 0), Quaternion.identity);
            walls[1] = Instantiate(wall, new Vector2(0, 4.65f), Quaternion.Euler(0,0,90));
            walls[2] = Instantiate(wall, new Vector2(2.5f, 0), Quaternion.identity);
            walls[0].GetComponent<Wall>().StopMoveWall(new Vector2(-2.5f, 3.5f));
            walls[1].GetComponent<Wall>().StopMoveWall(new Vector2(-0.8f, 4.65f));
            walls[2].GetComponent<Wall>().StopMoveWall(new Vector2(2.5f, 3.5f));
            bossState = true;
        }
        if (realTime > 180)
        {

            return;
        }
        if (pauseTimer <= 0)
        {
            if (timeSpawnEnemy == timerSpawn)
            {
                Enemies[ContSpawns].SetActive(true);
                Enemies[ContSpawns].GetComponent<Animator>().SetInteger("Pattern", nowPattern);
                Enemies[ContSpawns].GetComponent<Animator>().SetBool("Anim", false);
                ContSpawns++;
                if (ContSpawns == countEnemy)
                {
                    ContSpawns = 0;
                    nowPattern = Random.Range(1, 9);
                    pauseTimer = 100;
                }
                timerSpawn = 0;
            }
            else
                timerSpawn++;
        }
        else
            pauseTimer--;
    }


    /*
    private static int ActiveEnemyCount;

    private static int currentEnemyGroupNumber;

    //private GameObject[] Enemies;

    private List<GameObject> Enemies;// = new List<GameObject>();

    // Use this for initialization
    void Start() {
        ActiveEnemyCount = 0;

        currentEnemyGroupNumber = 0;

        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        Enemies = new List<GameObject>(enemy);

        SetAllEnemyActiveFlag(false);

        SetEnemycontrollerParam();
    }

    // Update is called once per frame
    void Update () {
        if(ActiveEnemyCount == 0)
        {
            DeleteCurrentEnemyArray();

            currentEnemyGroupNumber++;

            SetEnemycontrollerParam();
        }
    }

    private void SetEnemycontrollerParam()
    {
        ActiveEnemyCount = 0;
        foreach (GameObject enemy in Enemies)
        {
            if (enemy.GetComponent<Enemy>().enemyGroupNumber == currentEnemyGroupNumber)
            {
                ActiveEnemyCount++;
                enemy.SetActive(true);
            }
        }
        if (ActiveEnemyCount == 0)
        {
            ActiveEnemyCount++;
        }
    }

    private void DeleteCurrentEnemyArray()
    {
        for(int enemyCnt = Enemies.Count - 1;enemyCnt>=0;enemyCnt--)
        {
            if(Enemies[enemyCnt].GetComponent<Enemy>().enemyGroupNumber == currentEnemyGroupNumber)
            {
                GameObject gameObj = Enemies[enemyCnt];

                Enemies.RemoveAt(enemyCnt);

                Destroy(gameObj);
            }
        }
    }

    void SetAllEnemyActiveFlag(bool flag)
    {
        foreach (GameObject enemy in Enemies)
        {
            enemy.SetActive(flag);
        }
    }

    public static void SubActiveEnemyCount()
    {
        ActiveEnemyCount--;
        if (ActiveEnemyCount < 0)
            ActiveEnemyCount = 0;
    }*/
}

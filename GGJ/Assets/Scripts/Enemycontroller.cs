using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour {

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakPoint : MonoBehaviour {

    [SerializeField]
    private GameObject BossEnemyObj;

    private const string ENEMY_TAG = "Enemy";

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag==ENEMY_TAG)
        {
            if(collider.GetComponent<Enemy>().bombedFlag)
            {
                BossEnemyObj.GetComponent<BossEnemy>().SetDamageFromExplosion();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(new Vector3(0,12f,0));
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "GameController")
            gameObject.SetActive(false);
    }

}

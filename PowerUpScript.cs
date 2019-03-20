using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
           
            Debug.Log("powerup hit :" + gameObject.tag);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().powerUp(gameObject);


        }
    }
}

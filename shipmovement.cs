using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipmovement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.RotateAround(Vector3.zero, Vector3.down, speed * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunscript : MonoBehaviour {

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * (Time.deltaTime * rotateSpeed));

        //Debug.Log(gameObject.transform.rotation.eulerAngles.x + "<= 0");
        if (gameObject.transform.rotation.eulerAngles.x >= 200)
        {

            gameObject.GetComponent<Light>().intensity = gameObject.GetComponent<Light>().intensity - 0.005f;
        }
        else
        {
            if (gameObject.GetComponent<Light>().intensity <= 1.25f)
            {
                gameObject.GetComponent<Light>().intensity = gameObject.GetComponent<Light>().intensity + 0.005f;
            }
        }
		
	}
}

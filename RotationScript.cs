using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    //private Quaternion quatern;

    //private float timer = 0.0f;

    // Use this for initialization
    void Start () {
        //quatern = Quaternion.Euler(new Vector3(0.0f, Random.Range(-180.0f, 180.0f), 0.0f));
    }
	
	// Update is called once per frame
	void Update () {

        //timer += Time.deltaTime;

        //if (timer > 2)
      
        //    quatern = Quaternion.Euler(new Vector3(0.0f, Random.Range(-180.0f, 180.0f), 0.0f));
        //    timer = 0.0f;
        //}
        var randumm = Random.Range(-1, 1);

        transform.Rotate(new Vector3(45 + randumm, 30 + randumm, 60 + randumm) * Time.deltaTime / 3);
        //var rotationTest = transform.rotation = Random.rotation;

        //transform.rotation = Quaternion.Lerp(transform.rotation, quatern, Time.deltaTime);
    }
}

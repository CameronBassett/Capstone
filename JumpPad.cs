using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float speed;

    void OnTriggerStay(Collider other)
    {
        Debug.Log("jumpad hit" + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + (speed / 100), other.gameObject.transform.position.z);
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    Debug.Log("space pressed for jumppad");

            //    //other.gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + transform.up * speed);
            //    other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + (speed / 100), other.gameObject.transform.position.z);
            //}
           
        }
    }
}

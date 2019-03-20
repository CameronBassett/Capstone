using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowHit : MonoBehaviour {

    public bool hit = false;
    float depth = 0.15F;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Arrow")
        {

            if (!hit)
            {
                ArrowStick(other);
                hit = true;
            }
        }
    }
    void ArrowStick(Collision col)
    {

        // move the arrow deep inside the enemy or whatever it sticks to
        col.transform.Translate(depth * -Vector3.left);
        // Make the arrow a child of the thing it's stuck to
        transform.parent = col.transform;
       
        Destroy(gameObject.GetComponent<Rigidbody>());
        RemoveCollidersRecursively();
        
    }

    private void RemoveCollidersRecursively()
    {
        var allColliders = GetComponentsInChildren<Collider>();

        //var allRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (var childCollider in allColliders) Destroy(childCollider);
        //foreach (var rigidbody in allRigidbodies) Destroy(rigidbody);
    }


}
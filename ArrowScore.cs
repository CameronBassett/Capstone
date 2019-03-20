using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScore : MonoBehaviour {

    private GameObject GameEngine;
    private AudioSource audioSource;
    public bool hit = false;

    // Use this for initialization
    void Start () {
        GameEngine = GameObject.FindGameObjectWithTag("GameController");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {

            if (!hit)
            {

                audioSource.Play();
                GameObject temp = gameObject.transform.root.gameObject;
               // Debug.Log("temp" + temp.name);
                hit = true;
                GameEngine.GetComponent<GameManager>().scoreUpdate(temp);
                Destroy(gameObject, 8f);

            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

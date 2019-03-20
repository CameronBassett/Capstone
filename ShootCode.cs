using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCode : MonoBehaviour {

    public GameObject arrowPrefab;
    private GameObject GameManager;

    public float arrowSpeed;
    public float arrowMaxSpeed;
    public float ChargeSpeed;

    private bool charging;
    private bool reloading;

    private Animator animator;
    private AudioSource audioSource;

    public Transform arrowSpawn;
    public Transform arrowSpawn2;
    public Transform arrowSpawn3;

    private GameObject arrow;
    private GameObject arrow2;
    private GameObject arrow3;

    // Use this for initialization
    void Start () {
        reloading = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        GameManager = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            if (reloading == false)
            {
                Chargeup();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            if (reloading == false && charging == true)
            {
                Shoot();
                reloading = true;
            }else if (charging == false)
            {
                animator.SetTrigger("unDraw");
            }
        } 

        if (reloading == true)
        {
            StartCoroutine(reload());
        }
		
	}
    IEnumerator reload()
        {
        yield return new WaitForSeconds(0.6f);
        reloading = false;
    }

    void Shoot()
    {

        arrow = (GameObject)Instantiate(
        arrowPrefab,
        arrowSpawn.position,
        arrowSpawn.rotation);

        if (GameManager.GetComponent<GameManager>().tripleshot)
        {
            arrow2 = (GameObject)Instantiate(
            arrowPrefab,
            arrowSpawn2.position,
            arrowSpawn2.rotation);
            arrow3 = (GameObject)Instantiate(
            arrowPrefab,
            arrowSpawn3.position,
            arrowSpawn3.rotation);
        }
        if (GameManager.GetComponent<GameManager>().Splintershot)
        {
            arrow.GetComponent<ArrowLand>().splinterArrowSplitCheck = true;
            if (GameManager.GetComponent<GameManager>().tripleshot)
            {
                arrow2.GetComponent<ArrowLand>().splinterArrowSplitCheck = true;
                arrow3.GetComponent<ArrowLand>().splinterArrowSplitCheck = true;
            }
        }

        animator.ResetTrigger("ArrowDraw");
        animator.ResetTrigger("unDraw");
        animator.SetTrigger("ShotArrow");
        audioSource.Play();



        // Add velocity to the bullet
        arrow.GetComponent<Rigidbody>().velocity = arrow.transform.right * arrowSpeed;
        if (GameManager.GetComponent<GameManager>().tripleshot)
        {
            arrow2.GetComponent<Rigidbody>().velocity = arrow.transform.right * arrowSpeed;
            arrow3.GetComponent<Rigidbody>().velocity = arrow.transform.right * arrowSpeed;
        }

        // Des
        arrowSpeed = 1;
        Destroy(arrow, 8.0f);
        Destroy(arrow2, 8.0f);
        Destroy(arrow3, 8.0f);

    }

    void Chargeup()
    {
        charging = true;

        animator.ResetTrigger("unDraw");
        animator.ResetTrigger("ShotArrow");
        animator.SetTrigger("ArrowDraw");

        arrowSpeed = arrowSpeed + ChargeSpeed;

        if(arrowSpeed >= arrowMaxSpeed)
        {
            arrowSpeed = arrowMaxSpeed;
        }

        if (arrowSpeed <= 4)
        {
            charging = false;
            return;
        }
        else
        {
            charging = true;
        }
    }

 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLand : MonoBehaviour
{

    public bool splinterArrowSplitCheck = false;

    private int bounceCount = 1;

    public bool hit = false;
    float depth = 0.15F;

    private Vector3 oldVecValue;


    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (!hit && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().scattershot || !hit && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Splintershot)
        {
            oldVecValue = gameObject.GetComponent<Rigidbody>().velocity * 0.8f;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            gameObject.transform.right = Vector3.Slerp(gameObject.transform.right, gameObject.GetComponent<Rigidbody>().velocity.normalized, Time.deltaTime);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Other")
        {
            bounceCount++;
            
            if (!hit && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().scattershot || !hit && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Splintershot)
            {
                ContactPoint point = other.contacts[0];



                gameObject.GetComponent<Rigidbody>().velocity = Vector3.Reflect(oldVecValue, point.normal);
                if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().scattershot && bounceCount >= 3)
                {
                    hit = true;
                    Arrowstuck(other);
                }
                if (splinterArrowSplitCheck && !hit)
                {
                    splinterArrowSplitCheck = false;

                    var splitsecondarrow = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);

                    splitsecondarrow.GetComponent<Rigidbody>().velocity = Vector3.Reflect(oldVecValue, point.normal);

                    Destroy(splitsecondarrow, 5f);

                }
            }
            if (!hit && !GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().scattershot && !GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Splintershot)
            {
                //Debug.Log("scatteshot" + GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().scattershot);
                Arrowstuck(other);
                hit = true;
            } else if (bounceCount >= 10 || hit)
            {
                Arrowstuck(other);
                hit = true;
            }


        }
        if (other.gameObject.tag == "Target")
        {
            hit = true;
        }

    }

    void Arrowstuck(Collision col)
    {

        // move the arrow deep inside the enemy or whatever it sticks to
        gameObject.transform.Translate(depth * -Vector3.left);
        // Make the arrow a child of the thing it's stuck to
        transform.parent = gameObject.transform;

        Destroy(gameObject.GetComponent<Rigidbody>());
        Destroy(gameObject.GetComponent<Collider>());
    }
}
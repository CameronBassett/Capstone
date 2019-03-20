using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public TextMesh scoreTXT;

    private float randomvalue;

    private float scoreFloat;

    public bool countdownhit;
    private bool countdowndone;

    public float minPrice;
    public float maxPrice;
   
   

    // Use this for initialization
    void Start () {
        ScoreValue();
  
        

    }

    public void ScoreValue()
    {
        randomvalue = Random.Range(minPrice,maxPrice);
        scoreTXT.text = ("$" + System.Math.Round(randomvalue, 2));
        scoreFloat = randomvalue;

    }

    // Update is called once per frame
    void Update () {
        if (gameObject != null)
        {
            if (gameObject.GetComponent<ArrowScore>().hit)
            {
                countdownhit = true;
            }

            if (countdownhit)
            {

                randomvalue = randomvalue - 0.05f;
                scoreTXT.text = ("$" + System.Math.Round(randomvalue, 2));
                if (randomvalue <= 0.00f)
                {
    
                    countdownhit = false;
                    countdowndone = true;

                }

            }
            if (countdowndone)
            {
                randomvalue = 0.000001f;
                scoreTXT.text = ("$0.00");
            }

        }

    }

    public float ScoreFloat
    {
        get{
            return scoreFloat;
        }

        set{
            scoreFloat = value;
        }

    }
}

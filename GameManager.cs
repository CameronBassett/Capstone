using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour {

    public GameObject[] Targets;
    public GameObject[] SpawnPoints;

    public GameObject Menus;
    private bool menuActive = false;

    private GameObject chosenPoint;
    private GameObject Player;

    public float SpawnSpeed;

    private double currentScore;

    private AudioSource powerupGet;
    private AudioSource errorSound;
    private AudioSource songMusic;


    private bool spawnEnemy;

    public bool tripleshot;
    public bool scattershot;
    public bool Splintershot;
    public bool slowmo;


    public GameObject Target;
    public Text ScoreText;

    public GameObject reticleD;
    public GameObject reticleT;
    public GameObject reticleS;
    public GameObject reticleB;
    public GameObject iconPupS;
    public GameObject iconPupT;
    public GameObject iconPupB;

    // Use this for initialization
    void Start() {

        Targets = GameObject.FindGameObjectsWithTag("Target");
        SpawnPoints = GameObject.FindGameObjectsWithTag("Spawn");

        Player = GameObject.FindGameObjectWithTag("Player");


        foreach (GameObject value in Targets)
        {
            print(value.name);
        }
        currentScore = 0;
        ScoreText.text = "$0.00";

        spawnEnemy = true;

        var aSources = GetComponents<AudioSource>();


        songMusic = aSources[0];
        songMusic.time = 10f;
        songMusic.Play();

        errorSound = aSources[1];

        powerupGet = aSources[2];



    }

    public void scoreUpdate(GameObject target)
    {

        currentScore = currentScore + System.Math.Round(target.GetComponent<Score>().ScoreFloat, 2);
        ScoreText.text = "$" + currentScore;


    }

    private void scoreAdjust()
    {
        currentScore = System.Math.Round(currentScore, 2);
        ScoreText.text = "$" + currentScore;
    }

    // Update is called once per frame
    void Update() {


        if (spawnEnemy)
        {
            StartCoroutine(SpawnDelay());
            spawnEnemy = false;
        }

        if (Input.GetMouseButtonDown(1) && slowmo)
        {
            Time.timeScale = 0.3f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Menus.SetActive(true);
                menuActive = true;
                Time.timeScale = 0.1f;
                Player.GetComponent<FirstPersonController>().enabled = false;
                Player.GetComponentInChildren<ShootCode>().enabled = false;
            }
            else
            {
                Menus.SetActive(false);
                menuActive = false;
                Time.timeScale = 1;
                Player.GetComponent<FirstPersonController>().enabled = true;
                Player.GetComponentInChildren<ShootCode>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }

        }




    }

    public void powerUp(GameObject powerUp) {
        Debug.Log("before: " + currentScore);

        if (currentScore < powerUp.GetComponent<Score>().ScoreFloat)
        {
            errorSound.time = 0.5f;
            errorSound.Play();
        }

        if (powerUp.tag == "TripleshotPUP" && currentScore >= powerUp.GetComponent<Score>().ScoreFloat && !tripleshot)
        {
            powerUp.GetComponent<ArrowScore>().hit = true;
            powerupGet.Play();
            tripleshot = true;
            currentScore = currentScore - powerUp.GetComponent<Score>().ScoreFloat;
            scoreAdjust();
            reticleD.SetActive(false);
            reticleS.SetActive(false);
            reticleB.SetActive(false);
            reticleT.SetActive(true);
            iconPupT.SetActive(true);


        }
        else if (powerUp.tag == "ScattershotPUP" && currentScore >= powerUp.GetComponent<Score>().ScoreFloat && !scattershot)
        {
            powerUp.GetComponent<ArrowScore>().hit = true;
            powerupGet.Play();
            scattershot = true;
            currentScore = currentScore - powerUp.GetComponent<Score>().ScoreFloat;
            scoreAdjust();
            reticleD.SetActive(false);
            reticleS.SetActive(false);
            reticleB.SetActive(true);
            reticleT.SetActive(false);
            iconPupB.SetActive(true);

        }
        else if (powerUp.tag == "SplintershotPUP" && currentScore >= powerUp.GetComponent<Score>().ScoreFloat && !Splintershot)
        {
            powerUp.GetComponent<ArrowScore>().hit = true;
            powerupGet.Play();
            Splintershot = true;
            currentScore = currentScore - powerUp.GetComponent<Score>().ScoreFloat;
            scoreAdjust();
            reticleD.SetActive(false);
            reticleS.SetActive(true);
            reticleB.SetActive(false);
            reticleT.SetActive(false);
            iconPupS.SetActive(true);

        }
        else if (powerUp.tag == "SlowMoPUP" && currentScore >= powerUp.GetComponent<Score>().ScoreFloat && !slowmo)
        {
            powerUp.GetComponent<ArrowScore>().hit = true;
            powerupGet.Play();
            slowmo = true;
            currentScore = currentScore - powerUp.GetComponent<Score>().ScoreFloat;
            scoreAdjust();

        }

        Debug.Log("after: " + currentScore);
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(SpawnSpeed);

        int index = Random.Range(0, SpawnPoints.Length);
        chosenPoint = SpawnPoints[index];
        var TargetSpawn = (GameObject)Instantiate(Target, chosenPoint.transform.position, chosenPoint.transform.rotation);
        Destroy(TargetSpawn, 60f);
        spawnEnemy = true;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

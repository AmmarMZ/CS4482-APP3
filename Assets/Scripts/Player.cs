using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    [HideInInspector]public float score;
    [SerializeField] private GameObject fragmentedCubes;
    [HideInInspector] public static float currDist;
    private Animator animator;
    private bool isHopping;
    private bool isOnLog;
    private float maxDist = 0;
    public static bool isDead;
    private float timer = 0.0f;
    public static bool isPaused = false;
    public static string id = "";
    public static bool onTurtle;

    public static int coinsCollected = 0;
    public static int clocksCollected = 0;
    public static int deathByEnviro = 0;
    public static int deathByCar = 0;
    public static int logsRidden = 0;
    public static int turtlesRidden = 0;

    private float inGameTimer = 0.0f;
    public static bool isSpeedMode;

    void Start() {
        coinsCollected = 0;
        clocksCollected = 0;
        deathByEnviro = 0;
        deathByCar = 0;
        logsRidden = 0;
        turtlesRidden = 0;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        inGameTimer += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Escape) && isPaused) {
            SceneManager.UnloadSceneAsync(2);
            isPaused = false;
        }

        else if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
            isPaused = true;
        }

        float displayedScore = maxDist + score;
        scoreText.text = "Score :" + displayedScore;

        if (isDead) {
            timer += Time.deltaTime;
            if (timer % 60 >= 2) {
                timer = 0.0f;
                isDead = false; 
                LeaderBoard.updateLeaderBoard((int)displayedScore, id, isSpeedMode);
                LifeTimeStats.upateLifeTimeStats((int)displayedScore, coinsCollected, clocksCollected, (int)maxDist, deathByEnviro, deathByCar, logsRidden, turtlesRidden, inGameTimer);
                id = "";
                SceneManager.LoadScene(0);
            }
        }
        if (transform.localPosition.y < -0.21f && !isDead) {
            // super hacky way
            Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1);
            Vector3 spawnPos2 = new Vector3(transform.position.x -1, transform.position.y + 0.5f, transform.position.z -1);
            Instantiate(fragmentedCubes, spawnPos, transform.rotation);
            Instantiate(fragmentedCubes, spawnPos2, transform.rotation);
            transform.GetComponent<MeshRenderer>().enabled = false;
            deathByEnviro++;
            isDead = true;
        }   
   
        // forward
        if(Input.GetKeyDown(KeyCode.UpArrow) && !isHopping && !isDead) {

            maxDist = Mathf.Max(maxDist, transform.position.x + 2);
            float zDiff = 0;
           // make sure we are in a grid space not inbetween
           if (transform.position.z % 1 != 0) {
               zDiff =  Mathf.Round(transform.position.z) - transform.position.z;
           }
            MovePlayer(new Vector3(1,0,zDiff));
       }
       // left
       else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isHopping && !isDead) {
           
           MovePlayer(new Vector3(0,0,1));
       }
       // right
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isHopping && !isDead) {
           
           MovePlayer(new Vector3(0,0,-1));
       }
       // down
       else if (Input.GetKeyDown(KeyCode.DownArrow) && !isHopping && maxDist - transform.position.x <= 3 && !isDead) {
            float zDiff = 0;

            if (transform.position.z % 1 != 0) {
               zDiff =  Mathf.Round(transform.position.z) - transform.position.z;
           }
           MovePlayer(new Vector3(-1, 0, zDiff));
       }
       currDist = transform.position.x;
    }

    private void MovePlayer(Vector3 diff) {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.parent.position = transform.parent.position + diff;
        terrainGenerator.SpawnTerrain(false, transform.position, isSpeedMode);
    }
    public void finishHop() {
        isHopping = false;
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.collider.GetComponent<Movement>() != null) {
            if(collision.collider.GetComponent<Movement>().isLog) {
                transform.parent.parent = collision.collider.transform;
                onTurtle = false;
                logsRidden++;
            }
            if(collision.collider.GetComponent<Movement>().isTurtle) {
                 transform.parent.parent = collision.collider.transform;
                 onTurtle = true;
                 turtlesRidden++;
            } 
        }
        else {
            transform.parent.parent = null;
            onTurtle = false;
        }

    }
}

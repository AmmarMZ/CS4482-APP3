﻿using System.Collections;
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

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
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
                SceneManager.LoadScene(0);
                SceneManager.UnloadSceneAsync(1);
                timer = 0.0f;
                isDead = false; 
                LeaderBoard.updateLeaderBoard((int)displayedScore, id);
            }
        }
        if (transform.localPosition.y < -0.21f && !isDead) {
            // super hacky way
            Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1);
            Vector3 spawnPos2 = new Vector3(transform.position.x -1, transform.position.y + 0.5f, transform.position.z -1);
            Instantiate(fragmentedCubes, spawnPos, transform.rotation);
            Instantiate(fragmentedCubes, spawnPos2, transform.rotation);
            transform.GetComponent<MeshRenderer>().enabled = false;
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
        terrainGenerator.SpawnTerrain(false, transform.position);
    }
    public void finishHop() {
        isHopping = false;
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.collider.GetComponent<Movement>() != null) {
            if(collision.collider.GetComponent<Movement>().isLog) {
                transform.parent.parent = collision.collider.transform;
                onTurtle = false;

            }
            if(collision.collider.GetComponent<Movement>().isTurtle) {
                 transform.parent.parent = collision.collider.transform;
                 onTurtle = true;
            } 
        }
        else {
            transform.parent.parent = null;
            onTurtle = false;
        }

    }
}

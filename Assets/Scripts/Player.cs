using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    [HideInInspector]public float score;
    private Animator animator;
    private bool isHopping;
    private bool isOnLog;
    [HideInInspector] public static float currDist;
    private float maxDist = 0;
    [SerializeField] private GameObject fragmentedCubes;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (transform.localPosition.y < -0.2) {
            // super hacky way
            Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1);
            Instantiate(fragmentedCubes, spawnPos, transform.rotation);
            Destroy(transform.gameObject);
        }
        float temp = maxDist + score;
        scoreText.text = "Score :" + temp;;
        // forward
        if(Input.GetKeyDown(KeyCode.UpArrow) && !isHopping) {
            maxDist = Mathf.Max(maxDist, transform.position.x + 2);
           float zDiff = 0;
           // make sure we are in a grid space not inbetween
           if (transform.position.z % 1 != 0) {
               zDiff =  Mathf.Round(transform.position.z) - transform.position.z;
           }
            MovePlayer(new Vector3(1,0,zDiff));
       }
       // left
       else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isHopping) {
           
           MovePlayer(new Vector3(0,0,1));
       }
       // right
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isHopping) {
           
           MovePlayer(new Vector3(0,0,-1));
       }
       // down
       else if (Input.GetKeyDown(KeyCode.DownArrow) && !isHopping && maxDist - transform.position.x <= 3) {
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
            }
        }
        else {
            transform.parent.parent = null;
        }

    }
}

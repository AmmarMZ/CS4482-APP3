using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    private int score;
    private Animator animator;
    private bool isHopping;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate() {
        score++;
    }

    // Update is called once per frame
    void Update() {
        
        scoreText.text = "Score :" + score;
        if(Input.GetKeyDown(KeyCode.UpArrow) && !isHopping) {
           
           float zDiff = 0;
           // make sure we are in a grid space not inbetween
           if (transform.position.z % 1 != 0) {
               zDiff =  Mathf.Round(transform.position.z) - transform.position.z;
           }
            MovePlayer(new Vector3(1,0,zDiff));
       }
       else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isHopping) {
           
           MovePlayer(new Vector3(0,0,1));
       }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isHopping) {
           
           MovePlayer(new Vector3(0,0,-1));
       }
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
}

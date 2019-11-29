using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private GameObject fragmentedCubes;

    public bool isLog;
    public bool isTurtle;
    private float timer = 0.0f;


    void Update()
    {
        if (Player.isPaused) {
            // don't move
        }
        else if (Collectible.clockActive && !isLog) {
            timer += Time.deltaTime;
            transform.Translate(Vector3.back * 1 * Time.deltaTime);

            if (timer % 60 >= 10) {
                Collectible.clockActive = false;
                timer = 0.0f;
            }
            
        }   
        else {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
     
        // destroy obstacle once it passes outside width of road or water
        if (transform.position.z >= 26 || transform.position.z <= -26) {
            Destroy(transform.gameObject);
        }
        // destroy obstacle once player moves far
        if (Player.currDist - transform.position.x > 5) {
            Destroy(transform.gameObject);
        }
        if(TerrainGenerator.fallingXPosition >= transform.position.x && transform.position.x > 0) {
            if (transform.Find("Player")) {
                Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1);
                Vector3 spawnPos2 = new Vector3(transform.position.x -1, transform.position.y + 0.5f, transform.position.z -1);
                Instantiate(fragmentedCubes, spawnPos, transform.rotation);
                Instantiate(fragmentedCubes, spawnPos2, transform.rotation);
                transform.GetComponent<MeshRenderer>().enabled = false;
                Player.deathByEnviro++;
                Player.isDead = true;
            }
            else {
                Destroy(transform.gameObject);
            }
        }
    }
}

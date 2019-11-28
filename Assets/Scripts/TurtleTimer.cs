using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleTimer : MonoBehaviour {

    private float timer = 0.0f;
    [SerializeField] private float maxTime;
    [SerializeField] private GameObject fragmentedCubes;

    void Update() {

        if (transform.Find("Player") != null && !Player.isDead) {
            Debug.Log(timer % 60);
            timer += Time.deltaTime;
            if(timer % 60 >= maxTime) {
                Player.isDead = true;

                Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1);
                Vector3 spawnPos2 = new Vector3(transform.position.x -1, transform.position.y + 0.5f, transform.position.z -1);
                Instantiate(fragmentedCubes, spawnPos, transform.rotation);
                Instantiate(fragmentedCubes, spawnPos2, transform.rotation);
                timer = 0.0f;
                transform.Find("Player").Find("Cube").GetComponent<MeshRenderer>().enabled = false;
        }
        else  if (!Player.onTurtle){
            timer = 0.0f;
        }
    }
}

}
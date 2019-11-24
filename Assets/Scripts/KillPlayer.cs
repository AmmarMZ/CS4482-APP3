using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject fragmentedCubes;
    private Collision localCol;

    
    private void OnCollisionEnter(Collision collision) {

        if (collision.collider.GetComponent<Player>() != null) {

            Vector3 spawnPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1);
            Vector3 spawnPos2 = new Vector3(transform.position.x -1, transform.position.y + 0.5f, transform.position.z -1);
            Instantiate(fragmentedCubes, spawnPos, transform.rotation);
            Instantiate(fragmentedCubes, spawnPos2, transform.rotation);
            collision.collider.GetComponent<MeshRenderer>().enabled = false;
            Player.isDead = true;
        }
    }
}

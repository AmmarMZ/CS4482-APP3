using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject fragmentedCubes;
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<Player>() != null) {

            Vector3 spawnPos = new Vector3(collision.gameObject.transform.position.x - 1, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z - 1);
            Instantiate(fragmentedCubes, spawnPos, collision.gameObject.transform.rotation);

            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] List<GameObject> collectibles;
    
    // Start is called before the first frame update

    void Start() {
        spawnCollectible();
    }
    public void spawnCollectible() {
        int toSpawn = Random.Range(1, 20);
        // 2, 17 will spawn a collectible, i.e 10% chance of spawning
        if (toSpawn == 2 || toSpawn == 17) {
            int col = Random.Range(0,2);
            GameObject collectible = Instantiate(collectibles[col], spawnPos.position, Quaternion.identity, transform);
            //clock
            if (col == 0) {
                collectible.transform.Rotate(new Vector3(0,270,0));
            }
    	}
    }
}

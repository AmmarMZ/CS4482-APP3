using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnObject;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] public bool isRight;
    [SerializeField] private bool isRoad;
    [SerializeField] private bool isWater;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnVehicle());
    }
    
    private IEnumerator SpawnVehicle() {
        while(true) {

            int idx = 0;
            if(isWater) {
                int toSpawn = Random.Range(1, 20);
                // 2, 17 will spawn a collectible, i.e 10% chance of spawning
                if (toSpawn == 2 || toSpawn == 17) {
                    idx = 1;
                }
            }
            else if (isRoad) {
                idx = 0;
            }
            yield return new WaitForSeconds(Random.Range(minTime,maxTime));
            GameObject go = Instantiate(spawnObject[idx], spawnPos.position, Quaternion.identity, transform.parent);
            if (isRight) {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnVehicle());
    }
    
    private IEnumerator SpawnVehicle() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(minTime,maxTime));
            GameObject go = Instantiate(spawnObject, spawnPos.position, Quaternion.identity, transform.parent);
            if (isRight) {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}

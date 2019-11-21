using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _vehicle;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnVehicle() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(minTime,maxTime));
            Instantiate(_vehicle, spawnPos.position, Quaternion.identity);
        }
    }
}

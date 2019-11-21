﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _vehicle;
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
            GameObject go = Instantiate(_vehicle, spawnPos.position, Quaternion.identity);
            if (isRight) {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}

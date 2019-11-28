﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private bool isCoin;
    [SerializeField] private bool isClock;

    public static bool clockActive;
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<Player>() != null) {
            if (isClock) {
                Player.clocksCollected++;
                clockActive = true;
            }
            if (isCoin) {
                collision.collider.GetComponent<Player>().score += 10;
                Player.coinsCollected++;
            }
            Destroy(transform.gameObject);
        }
    }
}

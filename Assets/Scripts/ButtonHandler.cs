﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void loadLeaderboard() {
        SceneManager.LoadScene(3);
    }
    public void loadStats() {
        SceneManager.LoadSceneAsync(4);
    }
    public void goBack() {
        SceneManager.LoadScene(0);
    }
    public void speedMode() {
        SceneManager.LoadScene(1);
        Player.isSpeedMode = true;
        Player.isDead = false;
    }
    public void regulareMode() {
        SceneManager.LoadScene(1);
        Player.isSpeedMode = false;
        Player.isDead = false;
    }

    public void loadStore() {
        SceneManager.LoadScene(5);
    }
}

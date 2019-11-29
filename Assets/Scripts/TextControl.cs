using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class TextControl : EventTrigger
{
    public override void OnPointerClick(PointerEventData data) {

        if(GetComponent<Canvas>().tag.Equals("leaderboard")) {
            SceneManager.LoadScene(3);
        }
        else if(GetComponent<Canvas>().tag.Equals("start")) {
            if(Player.id.Length < 3) {
                return;
            }
            Player.isSpeedMode = false;
            SceneManager.LoadScene(1);
            Player.isDead = false;
        }
        else if (GetComponent<Canvas>().tag.Equals("exit")) {
            Application.Quit();
        }
        else if(GetComponent<Canvas>().tag.Equals("resume")) {
            SceneManager.UnloadSceneAsync(2);   
            Player.isPaused = false;
        }
       
        else if(GetComponent<Canvas>().tag.Equals("stats")) {
            SceneManager.LoadScene(4);
        }
        else if(GetComponent<Canvas>().tag.Equals("back")) {
            SceneManager.UnloadSceneAsync(3);
            SceneManager.LoadScene(0);
        }
        else if(GetComponent<Canvas>().tag.Equals("backStats")) {
            SceneManager.UnloadSceneAsync(4);
            SceneManager.LoadScene(0);
        }
        
    }
    
}

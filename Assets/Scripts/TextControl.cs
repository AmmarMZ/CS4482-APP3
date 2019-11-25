using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class TextControl : EventTrigger
{
    [SerializeField] private bool isStart;
    [SerializeField] private bool isExit;
    
    public override void OnPointerClick(PointerEventData data) {
        if(GetComponent<Canvas>().tag.Equals("start")) {
            SceneManager.LoadScene(1);
            Player.isDead = false;
        }
        else if (GetComponent<Canvas>().tag.Equals("exit")) {
            Debug.Log("Exit clicked");
            Application.Quit();
        }
        else if(GetComponent<Canvas>().tag.Equals("resume")) {
            SceneManager.UnloadSceneAsync(2);   
            Player.isPaused = false;
        }
    }
}

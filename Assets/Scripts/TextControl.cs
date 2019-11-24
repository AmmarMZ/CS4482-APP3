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
        }
        else if (GetComponent<Canvas>().tag.Equals("exit")) {
            Application.Quit();
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class TextControl2 : EventTrigger
{
    public override void OnPointerClick(PointerEventData data) {

        if(GetComponent<Canvas>().tag.Equals("leaderboard")) {
            SceneManager.LoadScene(3);
        }
    }
    
}

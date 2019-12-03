using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrentSkin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        string temp = ToggleHandler.currentlySelected;

        if (temp.Equals("None")) {
            
            transform.GetComponent<TextMesh>().text = "Default";
        }
        else if (temp.Length > 0) {
            transform.GetComponent<TextMesh>().text = ToggleHandler.currentlySelected;
        }
    }

}

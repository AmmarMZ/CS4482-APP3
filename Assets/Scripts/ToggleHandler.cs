using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class ToggleHandler : MonoBehaviour {

    [SerializeField] private Toggle redToggle;
    [SerializeField] private Toggle blueToggle;
    [SerializeField] private Toggle greenToggle;
    [SerializeField] private Toggle yellowToggle;

    private bool isRedBought;
    private bool isBlueBought;
    private bool isGreenBought;
    private bool isYellowBought;

    public static string currentlySelected = "None";

    private bool isStart;
      
    void Start() {

        if (currentlySelected != "None") {
            if (currentlySelected.Equals("blue")) {
                toggleBlue(true);
            }
            else if (currentlySelected.Equals("green")) {
                toggleGreen(true);
            }
            else if (currentlySelected.Equals("red")) {
                toggleRed(true);
            }
            else if (currentlySelected.Equals("yellow")) {
                toggleYellow(true);
            }
        }
        else {

        isStart = true;
        string [] lines = File.ReadAllLines(@"C:\amirza28\" + "balance.txt");  
        int buyBlue = Int32.Parse(lines[1].Split(':')[1]);
        int buyRed = Int32.Parse(lines[2].Split(':')[1]);
        int buyGreen = Int32.Parse(lines[3].Split(':')[1]);
        int buyYellow = Int32.Parse(lines[4].Split(':')[1]);

        currentlySelected  = "None";
        isBlueBought = buyBlue == 1;
        isRedBought = buyRed == 1;
        isGreenBought = buyGreen == 1;
        isYellowBought = buyYellow == 1;

        if (isRedBought) {
            redToggle.isOn = true;
            currentlySelected = "red";
        }
          
        if (isBlueBought) {
            if (isRedBought) {
                blueToggle.isOn = false;
            }
            else {
                blueToggle.isOn = true;
                currentlySelected = "blue";
            }
        }
    
        if(isGreenBought) {
            if (isRedBought || isBlueBought){
                greenToggle.isOn = false;
            }
            else {
                greenToggle.isOn = true;
                currentlySelected = "green";
            }
        }
        
        if (isYellowBought) {
            if (isRedBought || isBlueBought || isGreenBought) {
                yellowToggle.isOn = false;
            }
            else {
                yellowToggle.isOn = true;
                currentlySelected = "yellow";
            }
        }

        isStart = false;
        }
    }
    public void toggle(bool val, String name) {
        
        if(val && !isStart) {
           if (name.Equals("red")) {
               toggleGreen(false);
               toggleBlue(false);
               toggleYellow(false);
           }
           else if(name.Equals("blue")) {
               toggleRed(false);
               toggleGreen(false);
               toggleYellow(false);
           }
           else if (name.Equals("green")) {
               toggleRed(false);
               toggleBlue(false);
               toggleYellow(false);
           }
           else if (name.Equals("yellow")) {
               toggleRed(false);
               toggleBlue(false);
               toggleGreen(false);
           }
        }
        else if (!val) {
            if(redToggle.isOn) {
                currentlySelected = "red";
            }
            else if (blueToggle.isOn) {  
                currentlySelected = "blue";
            }
            else if (greenToggle.isOn) {
                currentlySelected = "green";
            }
            else if (yellowToggle.isOn) {    
                currentlySelected = "yellow";
            }
            else {
                currentlySelected = "None";
            }
        }
    }

    public void toggleRed(bool val) {
        redToggle.isOn = val;
    }
    private void toggleBlue(bool val) {
        blueToggle.isOn = val;
    }
    private void toggleGreen(bool val) {
        greenToggle.isOn = val;
    }
    private void toggleYellow(bool val) {
        yellowToggle.isOn = val;
    }
    

}

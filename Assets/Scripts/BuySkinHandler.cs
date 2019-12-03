using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;


public class BuySkinHandler : MonoBehaviour
{
    
    public bool isRed;
    public bool isBlue;
    public bool isGreen;
    public bool isYellow;

    private static int curBalance = 0;

    [SerializeField] private GameObject button;


    void Start() {
        string [] lines = File.ReadAllLines(@"C:\amirza28\" + "balance.txt");  
        curBalance = Int32.Parse(lines[0].Split(':')[1]);

        ColorBlock cb = button.GetComponent<Button>().colors;
        cb.pressedColor = Color.red;

        if(isRed) {
             if (curBalance < 10) {
                GetComponent<Button>().colors = cb;
             }
        }
        if(isBlue) {
             if (curBalance < 20) {
                GetComponent<Button>().colors = cb;
             }
        }
        if(isGreen) {
             if (curBalance < 40) {
                GetComponent<Button>().colors = cb;
             }
        }
        if(isYellow) {
            if (curBalance < 80) {
                GetComponent<Button>().colors = cb;
            }
        }
           
    }

    void Update() {
        ColorBlock cb = button.GetComponent<Button>().colors;
        cb.pressedColor = Color.red;

        if (isRed) {
            if (SkinStore.isRedBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
            if (curBalance < 10) {
                GetComponent<Button>().colors = cb;
             }
        }
        else if (isBlue) {
            if (SkinStore.isBlueBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
            if (curBalance < 20) {
                GetComponent<Button>().colors = cb;
             }
        }
        else if (isGreen) {
            if (SkinStore.isGreenBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
            if (curBalance < 40) {
                GetComponent<Button>().colors = cb;
             }
        }
        else if (isYellow) {
            if (SkinStore.isYellowBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
            if (curBalance < 80) {
                GetComponent<Button>().colors = cb;
            }
        }
    }

    public void buyBlue() {
        if (SkinStore.balances[0] >= 20) {
            SkinStore.balances[0] -= 20;
            SkinStore.isBlueBought = true;
            SkinStore.updateBankAccount(0, true, 20, 1);
            curBalance -= 20;
        }
    }

    public void buyRed() {
        if (SkinStore.balances[0] >= 10) {
            SkinStore.balances[0] -= 10;
            SkinStore.isRedBought = true;
            SkinStore.updateBankAccount(0, true, 10, 2);
            curBalance -= 10;
        }
    }
    
    public void buyGreen() {
        if (SkinStore.balances[0] >= 40) {
            SkinStore.balances[0] -= 40;
            SkinStore.isGreenBought = true;
            SkinStore.updateBankAccount(0, true, 40, 3);
            curBalance -= 40;
        }

    }

    public void buyYellow() {
        if (SkinStore.balances[0] >= 80) {
            SkinStore.balances[0] -= 80;
            SkinStore.isYellowBought = true;
            SkinStore.updateBankAccount(0, true, 80, 4);
            curBalance -= 80;
        }
    }
}

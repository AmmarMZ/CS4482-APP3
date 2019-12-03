using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class BuySkinHandler : MonoBehaviour
{
    
    public bool isRed;
    public bool isBlue;
    public bool isGreen;
    public bool isYellow;

    [SerializeField] private GameObject button;


    void Start() {

    }

    void Update() {
        if (isRed) {
            if (SkinStore.isRedBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
        }
        else if (isBlue) {
            if (SkinStore.isBlueBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
        }
        else if (isGreen) {
            if (SkinStore.isGreenBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
        }
        else if (isYellow) {
            if (SkinStore.isYellowBought) {
                GetComponent<CanvasRenderer>().SetAlpha(0);
                button.SetActive(false);
            }
        }
    }

    public void buyBlue() {
        if (SkinStore.balances[0] >= 20) {
            SkinStore.balances[0] -= 20;
            SkinStore.isBlueBought = true;
            SkinStore.updateBankAccount(0, true, 20, 1);
        }
    }

    public void buyRed() {
        if (SkinStore.balances[0] >= 10) {
            SkinStore.balances[0] -= 10;
            SkinStore.isRedBought = true;
            SkinStore.updateBankAccount(0, true, 10, 2);
        }
    }
    
    public void buyGreen() {
        if (SkinStore.balances[0] >= 40) {
            SkinStore.balances[0] -= 40;
            SkinStore.isGreenBought = true;
            SkinStore.updateBankAccount(0, true, 40, 3);
        }

    }

    public void buyYellow() {
        if (SkinStore.balances[0] >= 80) {
            SkinStore.balances[0] -= 80;
            SkinStore.isYellowBought = true;
            SkinStore.updateBankAccount(0, true, 80, 4);
        }
    }
}

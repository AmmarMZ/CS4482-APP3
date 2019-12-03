using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;

public class SkinStore : MonoBehaviour
{

    public static string path = @"C:\amirza28\";
    public static string balance = "balance.txt";

    public bool coinBalance;

    public static string[] accountBalanceAndSkins;
    public static int [] balances;
    
    public static bool isBlueBought = false;
    public static bool isRedBought = false;
    public static bool isGreenBought = false;
    public static bool isYellowBought = false;

    void Start()
    {
        initialize();
        accountBalanceAndSkins = new string [5];
        balances = new int [5];
   
        int i = 0;
        string [] lines = File.ReadAllLines(path + balance);  
        
        foreach (string line in lines) {

            String [] temp = line.Split(':');

            accountBalanceAndSkins[i] = line;
            balances[i] = Int32.Parse(temp[1]);

            // blue
            if(i == 1) {
                if(temp.Length == 2) {    
                    if (Int32.Parse(temp[1]) == 1) {
                        isBlueBought = true;
                    }
                    else {
                        isBlueBought = false;
                    }
                }
            }
            // red
            else if (i == 2) {
                if(temp.Length == 2) {    
                    if (Int32.Parse(temp[1]) == 1) {
                        isRedBought = true;
                    }
                    else {
                        isRedBought = false;
                    }
                }
            }
            // green
            else if (i == 3) {
                if(temp.Length == 2) {    
                    if (Int32.Parse(temp[1]) == 1) {
                        isGreenBought = true;
                    }
                    else {
                        isGreenBought = false;
                    }
                }
            }
            // yellow
            else if (i == 4) {
                if(temp.Length == 2) {    
                    if (Int32.Parse(temp[1]) == 1) {
                        isYellowBought = true;
                    }
                    else {
                        isYellowBought = false;
                    }
                }
            }
            i++;
            
        }       
    }

    public static void initialize() {
        if(!File.Exists(path + balance)) {
            if (!Directory.Exists(path)) {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            using (StreamWriter sw = File.CreateText(path + balance)) {
                sw.Close();
            }

            string [] trueOutput = new string [5] {
                "Account Balance: 0",
                "Blue: 0",
                "Red: 0",
                "Green: 0",
                "Yellow: 0",
            };
            File.WriteAllLines(path + balance, trueOutput);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (coinBalance) {
            transform.gameObject.GetComponent<TextMesh>().text = "Account Balance: " + balances[0].ToString();
        }
    }

    public static void updateBankAccount(int coinsCollected, bool isBuying, int toSubtract, int idx) {
        coinsCollected *= 10;
        initialize();
        string [] lines = File.ReadAllLines(path + balance);  
        string [] headers = new string [5] {
            "Account Balance: ", 
            "Blue: ",
            "Red: ",
            "Green: ",
            "Yellow: ",
            };


        if (lines[0].Length != 0) {
            String [] temp = lines[0].Split(':');
            if(temp.Length == 2) {    
                int val = Int32.Parse(temp[1]);
                if (isBuying) {
                    val -= toSubtract;
                    lines[idx] = headers[idx] + 1;
                }
                else {
                    val += coinsCollected; 
                }
                lines[0] = headers[0] + val;
            }
        }

       File.WriteAllLines(path + balance, lines);
    }
}

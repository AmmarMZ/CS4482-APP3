using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;

public class LifeTimeStats : MonoBehaviour
{

    //Struc

    public static string path = @"C:\amirza28\";
    public static string stats = "stats.txt";

    public bool inGameTime;
    public bool totalScore;
    public bool coinsCollected;
    public bool clocksCollected;
    public bool totalDistance;
    public bool deathByEnviro;
    public bool deathByCar;
    public bool logsRidden;
    public bool turtlesRidden;

    public static string[] statArray;
    void Start()
    {
        initialize();
        statArray = new string [9];
        statArray[0] = "00:00:00";
        statArray[1] = "0";
        statArray[2] = "0";
        statArray[3] = "0";
        statArray[4] = "0";
        statArray[5] = "0";
        statArray[6] = "0";
        statArray[7] = "0";
        statArray[8] = "0";


        int i = 0;
        string [] lines = File.ReadAllLines(path + stats);  
        
        foreach (string line in lines) {
            statArray[i++] = line;
        }       
    }

    public static void initialize() {
        if(!File.Exists(path + stats)) {
            if (!Directory.Exists(path)) {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            using (StreamWriter sw = File.CreateText(path + stats)) {
                sw.Close();
            }

            string [] trueOutput = new string [9] {
                "Score: 0",
                "Coins collected: 0",
                "Clocks Collected: 0",
                "Total Distance: 0",
                "Deaths By Environment: 0",
                "Deaths By Car: 0",
                "Logs Ridden: 0",
                "Turtles Ridden: 0", 
                "Total Time Played: 0"
            };
            File.WriteAllLines(path + stats, trueOutput);
            }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (totalScore) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[0];
        }
        if (coinsCollected) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[1];
        }
        if (clocksCollected) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[2];
        }
        if (totalDistance) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[3];
        }
        if (deathByEnviro) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[4];
        }
        if (deathByCar) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[5];
        }
        if (logsRidden) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[6];
        }
        if (turtlesRidden) {
            transform.gameObject.GetComponent<TextMesh>().text = statArray[7];
        }
        if (inGameTime) {

            int time = Int32.Parse(statArray[8].Split(':')[1]);
            TimeSpan t = TimeSpan.FromSeconds((Double)time);
            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", 
                t.Hours, 
                t.Minutes, 
                t.Seconds, 
                t.Milliseconds);

            transform.gameObject.GetComponent<TextMesh>().text = "Total In Game Time: " + answer;
        }
    }

    public static void upateLifeTimeStats(int score, int coinsCollected, int clocksCollected, int distTravelled, int deathByEnviro, int deathBycar, int logsRidden, int turtlesRidden, float timePlayed)
    {
        initialize();
        string [] lines = File.ReadAllLines(path + stats);  
        string [] trueOutput = new string [9] {"0","0","0","0","0","0","0","0", "0"};
        string [] headers = new string [9] {
            "LifeTime Score: ", 
            "Coins collected: ",
            "Clocks Collected: ",
            "Total Distance: ",
            "Deaths By Environment: ",
            "Deaths By Car: ", 
            "Logs Ridden: ",
            "Turtles Ridden: ",
            "Total Time Played: "
            };


        for (int i = 0; i < lines.Length; i++) {
            if (lines[i].Length != 0) {
                String [] temp = lines[i].Split(':');
                int val = Int32.Parse(temp[1]);
                if(temp.Length == 2) {    
                    if(i == 0)
                        val += score;
                    if(i == 1)
                        val += coinsCollected;
                    if(i == 2)
                        val += clocksCollected;
                    if(i == 3)
                        val += distTravelled;
                    if (i == 4)
                        val += deathByEnviro;
                    if (i == 5)
                        val += deathBycar;
                    if (i == 6)
                        val += logsRidden;
                    if(i == 7)
                        val += turtlesRidden;
                    if(i == 8)
                        val += (int)timePlayed; 
                }
                trueOutput[i] = headers[i] + val;
            }
        }
       File.WriteAllLines(path + stats, trueOutput);
    }
}

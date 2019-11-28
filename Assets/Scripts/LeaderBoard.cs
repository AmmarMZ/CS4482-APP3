using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;

public class LeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public static string path = @"C:\amirza28\";
    public static string scores = "scores.txt";
    public bool isFirst;
    public bool isSecond;
    public bool isThird;
    public static string[] scoreArray;
    void Start()
    {
        initialize();
        scoreArray = new string [3];
        scoreArray[0] = "N/A";
        scoreArray[1] = "N/A";
        scoreArray[2] = "N/A";

        int i = 0;
        string [] lines = File.ReadAllLines(path + scores);  
        foreach (string line in lines) {
            scoreArray[i++] = line;
        }       
    }

    public static void initialize() {

        if (!Directory.Exists(path))
        {
            Debug.Log("doesn't exist");
            DirectoryInfo di = Directory.CreateDirectory(path);
            using (StreamWriter sw = File.CreateText(path + scores))
            {
                sw.Close();
            }
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (isFirst)
        {
            GetComponent<TextMesh>().text = scoreArray[0];
        }
        if (isSecond)
        {
            GetComponent<TextMesh>().text = scoreArray[1];
        }
        if (isThird)
        {
            GetComponent<TextMesh>().text = scoreArray[2];
        }
    }

    public static void updateLeaderBoard(int score, String id)
    {
        string [] lines = File.ReadAllLines(path + scores);  
        string [] trueOutput = new string [3] {"","",""};
        PlayerObj [] po = new PlayerObj[4];


        //C5.IPriorityQueue<PlayerObj> pq = new C5.IntervalHeap<PlayerObj>();

        for (int i = 0; i < lines.Length; i++) {
            if (lines[i].Length != 0) {
                String [] temp = lines[i].Split(':');
                if(temp.Length == 2) {
                    po[i] = new PlayerObj(temp[0], Int32.Parse(temp[1]));
                }
            }
        }
        po[3] = new PlayerObj(id,score);
        Array.Sort(po, PlayerObj.sortScoreDescending());    

         for (int i = 0; i < 3; i++) {
            if (po[i] != null) {
                trueOutput[i] = po[i].id.ToUpper() +": " + po[i].score;
            }
        } 
        File.WriteAllLines(path + scores, trueOutput);
    }
}

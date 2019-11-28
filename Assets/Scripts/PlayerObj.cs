using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerObj : IComparer {
    public String id;
    public int score;

    public PlayerObj(String id, int score) {
        this.id = id;
        this.score = score;
    }

    public PlayerObj() {}

        int IComparer.Compare(object a, object b)
        {
            
            PlayerObj one = (PlayerObj)a;
            PlayerObj two = (PlayerObj)b;

            if (one == null) {
                return 1;
            }
            if (two == null) {
                return -1;
            }
            return two.score - one.score;
        }

        public static IComparer sortScoreDescending() {
        return (IComparer) new PlayerObj();
    }
}

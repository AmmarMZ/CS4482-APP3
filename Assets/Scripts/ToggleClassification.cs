using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class ToggleClassification : MonoBehaviour {


      
    public void toggleRed(bool val) {
       GetComponentInParent<ToggleHandler>().toggle(val,"red");
    }
    public void toggleBlue(bool val) {
        GetComponentInParent<ToggleHandler>().toggle(val,"blue");
    }
    public void toggleGreen(bool val) {
          GetComponentInParent<ToggleHandler>().toggle(val,"green");
    }
    public void toggleYellow(bool val) {
        GetComponentInParent<ToggleHandler>().toggle(val,"yellow");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStart : MonoBehaviour
{
    [SerializeField] private GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.id.Length < 3){
            GetComponent<CanvasRenderer>().SetAlpha(0);
            button.SetActive(false);
        }
        else {
            GetComponent<CanvasRenderer>().SetAlpha(1);
            button.SetActive(true);
        }
    }
}

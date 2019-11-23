using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed;
    public bool isLog;
    public float timer = 0.0f;

    void Update()
    {
        if (Collectible.clockActive && !isLog) {
            timer += Time.deltaTime;
            transform.Translate(Vector3.back * 1 * Time.deltaTime);

            if (timer % 60 >= 10) {
                Collectible.clockActive = false;
                timer = 0.0f;
            }
            
        }   
        else {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
     
        // destroy obstacle once it passes outside width of road or water
        if (transform.position.z >= 26 || transform.position.z <= -26) {
            Destroy(transform.gameObject);
        }
        // destroy obstacle once player moves far
        if (Player.currDist - transform.position.x > 5) {
            Destroy(transform.gameObject);
        }
    }
}

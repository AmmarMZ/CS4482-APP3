using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isLog;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

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

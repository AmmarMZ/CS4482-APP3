using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<Player>() != null) {
            Destroy(collision.gameObject);
        }
    }
}

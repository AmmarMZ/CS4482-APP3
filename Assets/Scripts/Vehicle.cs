using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private IEnumerator SpawnVehicle() {
        yield return new WaitForSeconds(Random.Range(minTime,maxTime));
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<Player>() != null) {
            Destroy(collision.gameObject);
        }
    }
}

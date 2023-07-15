using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    ObjectPooler objectPooler;
    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }
    private void FixedUpdate() {
        objectPooler.SpawnFromPool("Square", (transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f))).normalized, Quaternion.identity);
        objectPooler.SpawnFromPool("Circle", (transform.position + new Vector3(Random.Range(20.0f, 20.0f), 0, Random.Range(30.0f, 30.0f))).normalized, Quaternion.identity);

    }
}

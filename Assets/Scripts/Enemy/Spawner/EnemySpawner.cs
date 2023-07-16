using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    ObjectPooler objectPooler;
    [SerializeField] private GameObject enemySpawnPoint;
    [SerializeField] private Player player;

    private Vector3 spawnPosition;
    private bool done = false;
    private void Start() {
        objectPooler = ObjectPooler.Instance;
        if (enemySpawnPoint != null) {
            spawnPosition = enemySpawnPoint.transform.position;
        }
    }
    private void FixedUpdate() {

        if (spawnPosition != null) {
            //objectPooler.SpawnFromPool("Square", RandomCircle(spawnPosition, 10f).normalized, Quaternion.identity);
            Debug.Log("enemySpawnPoint" + spawnPosition);
            if (!done) {
                for (int i = 0; i < 50; i++) {
                    objectPooler.SpawnFromPool("Square", RandomPointOnACircleEdge(spawnPosition, 10f), Quaternion.identity);
                    //objectPooler.SpawnFromPool("Square", (transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f))).normalized, Quaternion.identity);
                    //    objectPooler.SpawnFromPool("Circle", (transform.position + new Vector3(Random.Range(20.0f, 20.0f), 0, Random.Range(30.0f, 30.0f))).normalized, Quaternion.identity);
                    done = true;
                }
            }       
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius) {
        // Create random angle between 0 to 360 degrees
        float ang = Random.value * 360;
        Vector3 position;
        position.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        position.y = center.y;
        position.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return position;
    }

    private Vector3 RandomPointOnACircleEdge(Vector3 center, float radius) {
        Vector2 point = Random.insideUnitCircle.normalized * radius;
        return new Vector3(point.x + center.x, point.y + center.y, 0 + center.z);
    }
}

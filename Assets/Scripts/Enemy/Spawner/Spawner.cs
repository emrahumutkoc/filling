using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] Player player;
    private float diaEnemySpawn = 60f;
    private float interval = 3f;

    private void Start() {
        Debug.Log("position of player" + player.transform.position);
        StartCoroutine(spawnEnemy(interval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}

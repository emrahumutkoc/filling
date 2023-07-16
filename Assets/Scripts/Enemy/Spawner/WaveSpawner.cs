using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private GameObject spawnPoint;
    public List<EnemyData> enemies = new List<EnemyData>();
    public int currWave;
    public int waveValue;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateWave() {
        waveValue = currWave * 10;
        GenerateEnemies();
    }

    public void GenerateEnemies() {
        // Geçici bir düþman listesi oluþtur
        // loop ile bir düþmaný al ve kullanýlabilir olup olmadýðýný kontrol et
        // eðer kullanbilabilirse listeye ekle. maaliyeti azalt.
        // tekrarla
        // eðer hiçbir nokta kalmadýysa, loopu kapat.

        List<GameObject> generatedEnemies = new List<GameObject>();
    }
}

[System.Serializable]
public class EnemyData {
    public GameObject enemyPrefab;
    public int cost;
}

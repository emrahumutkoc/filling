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
        // Ge�ici bir d��man listesi olu�tur
        // loop ile bir d��man� al ve kullan�labilir olup olmad���n� kontrol et
        // e�er kullanbilabilirse listeye ekle. maaliyeti azalt.
        // tekrarla
        // e�er hi�bir nokta kalmad�ysa, loopu kapat.

        List<GameObject> generatedEnemies = new List<GameObject>();
    }
}

[System.Serializable]
public class EnemyData {
    public GameObject enemyPrefab;
    public int cost;
}

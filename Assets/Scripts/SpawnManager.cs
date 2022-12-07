using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefabs[0], Positioner() + new Vector3(0,0.4f,0), powerupPrefabs[0].transform.rotation);
        Instantiate(powerupPrefabs[2], Positioner() + new Vector3(0, 0.4f, 0), powerupPrefabs[2].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++; 
            SpawnEnemyWave(waveNumber);

        }
      
    }

    private Vector3 Positioner()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        

        Vector3 randomPos = new Vector3(randomX, 0f, randomZ);
        return randomPos;

      

    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs[0], Positioner(), enemyPrefabs[0].transform.rotation);

        }
        if (enemiesToSpawn == 3)
        {
            Instantiate(enemyPrefabs[1], Positioner(), enemyPrefabs[1].transform.rotation);
            Instantiate(powerupPrefabs[1], Positioner() + new Vector3(0, 0.4f, 0), powerupPrefabs[1].transform.rotation);
            Instantiate(powerupPrefabs[2], Positioner() + new Vector3(0, 0.4f, 0), powerupPrefabs[2].transform.rotation);
        }
        else if (enemiesToSpawn == 5)
        {
            Instantiate(powerupPrefabs[2], Positioner() + new Vector3(0, 0.4f, 0), powerupPrefabs[2].transform.rotation);
        }
    }
   

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPosition : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateEnemyPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            // "waveNumber++" also means "waveNumber = waveNumber + 1" AND "waveNumber +=1".
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateEnemyPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // A "for-loop" lets us use a method (like "Instantiate") multiple times. Like 5 or 10 times. WITH for "for-loop" you could set the end condition of when the "for-loop" would stop.
        // This is called a "for-loop". We need three different parameters for a "for-loop". First, we need to tell the "for-loop" when to start by creating a variable (i = 0). 
        // Second, tell the "for-loop" the condition of when it should stop by creating another variable (i < 3), which means that as long as "i" is less than 3, then it should continue. It will repeat for 3 times then the for-loop will stop.
        // Third, we need to tell the "for-loop" how it will get from 0 to 3 by writing an equation (i = i + 1) or (i +=1) or (i++). WHICH ALL MEAN THE SAME THING.
       for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateEnemyPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateEnemyPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return spawnPos;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

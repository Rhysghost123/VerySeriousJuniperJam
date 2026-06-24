using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] enemyPrefabs;   // Assign enemy prefabs in Inspector
    public int maxWaves = 3;
    public float timeBetweenWaves = 3f;
    public int enemiesPerWave = 2;

    // FIX #10: IsFinished is now a public property so GameManager can poll it
    // via AllSpawnersFinished(). Previously there was no way to know when
    // spawning was done, so phase 2 was never reached.
    public bool IsFinished { get; private set; } = false;

    public static int activeEnemies = 0;
    private bool isSpawning = false;

    void Start()
    {
       
        // instantiated dynamically (not pre-assigned in Inspector) are still tracked.
        if (GameManager.instance != null)
            GameManager.instance.RegisterSpawner(this);
    }

    
    // rather than calling SpawnEnemy() directly in a loop it controlled itself.
    // This gives the spawner full ownership of its own wave logic.
    public void StartSpawning()
    {
        if (!isSpawning)
            StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        isSpawning = true;
        IsFinished = false;

        for (int wave = 0; wave < maxWaves; wave++)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
            }

            // Wait until all enemies from this wave are dead before next wave
            yield return new WaitUntil(() => activeEnemies <= 0);
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        IsFinished = true;
        isSpawning = false;
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogWarning("EnemySpawner has no enemy prefabs assigned!", this);
            return;
        }

        // Pick a random enemy prefab from the array
        int index = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[index], transform.position, Quaternion.identity);

        activeEnemies++;

    }

}
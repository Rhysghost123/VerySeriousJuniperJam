using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public EnemyComponent[] enemies;
    public int spawnLimit;
    public int amountSpawned;
    
    void Start()
    {
        amountSpawned = 0;
        spawnLimit = GameManager.instance.currentRoom * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SpawnEnemy() 
{ 
    if (amountSpawned < spawnLimit) 
    { 
        // 1. Check if the entire array exists
        if (enemies == null)
        {
            Debug.LogError("The 'enemies' array itself is completely null! Assign it in the Inspector.");
            return;
        }

        // 2. Check if the array is empty
        if (enemies.Length == 0)
        {
            Debug.LogError("The 'enemies' array size is 0. Add elements in the Inspector.");
            return;
        }

        int random = UnityEngine.Random.Range(0, enemies.Length); 
        EnemyComponent enemyPrefab = enemies[random];

        // 3. Check if the specific chosen slot is empty
        if (enemyPrefab == null)
        {
            Debug.LogError($"Slot index {random} inside the 'enemies' array is empty!");
            return;
        }

        // If everything passes, spawn safely
        Instantiate(enemyPrefab, transform.position, Quaternion.identity); 
        amountSpawned++; 
    } 
}
}

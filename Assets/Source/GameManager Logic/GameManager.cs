using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool isGameActive;
    public int currentRoom = 1;

    public static GameManager instance;
    public EnemySpawner[] enemySpawners;


    public int phase = 0; //phase 0: The phase where nothing is spawned yet, and the slot machine is in the middle of the dungeon, waiting to be spun
    //phase 1: The phase where enemies are spawned and the player is fighting them
    //phase 2: The phase where the enemies are defeated and the chest appears 


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnEnemies()
    {
        while (phase == 1)
        {
            yield return new WaitForSeconds(1f);
            foreach (var spawner in enemySpawners)
            {
                spawner.SpawnEnemy();
            }
        }
    }
}
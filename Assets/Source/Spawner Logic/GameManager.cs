using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public int currentRoom = 1;
    public int roomsCleared;

    public static GameManager instance;
    public EnemySpawner[] enemySpawners;
    private ExitDoor exitDoor;

    // phase 0: Nothing spawned yet, slot machine waiting to be spun
    // phase 1: Enemies are spawned, player is fighting
    // phase 2: Enemies defeated, chest appears
    public int phase = 0;

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
        return; // Early return — no point continuing on the duplicate
    }

    GameObject exitObj = GameObject.FindGameObjectWithTag("Exit");
    if (exitObj != null)
        exitDoor = exitObj.GetComponent<ExitDoor>();

    if (exitDoor != null)
        exitDoor.unLightDoor();
}

    void Update()
    {
    }

    
    public IEnumerator SpawnEnemies()
    {
        
        // for them to report back that they're finished, rather than looping
        // forever with no exit condition.
        foreach (var spawner in enemySpawners)
        {
            spawner.StartSpawning();
        }

        // Wait until all spawners are done (all enemies killed)
        yield return new WaitUntil(() => AllSpawnersFinished());

        
        phase = 2;
        OnAllEnemiesDefeated();
    }

    bool AllSpawnersFinished()
    {
        foreach (var spawner in enemySpawners)
        {
            if (!spawner.IsFinished)
                return false;
        }
        return true;
    }

    void OnAllEnemiesDefeated()
    {
        Debug.Log("All enemies defeated! Phase 2: Chest appears.");
        UnregisterSpawners();


        GameObject exitObj = GameObject.FindGameObjectWithTag("Exit");
    if (exitObj != null)
        exitDoor = exitObj.GetComponent<ExitDoor>();

    if (exitDoor != null)
        exitDoor.unLightDoor();

        exitDoor.lightDoor();
        // TODO: Spawn chest / trigger reward logic here
    }

     public void startGame()
    {
        SceneManager.LoadScene("Main");
        isGameActive = true;
    }

    public void endGame()
    {
        //SceneManager.LoadScene("GameOver");
        isGameActive = false;
    }
    public void restartGame()
    {
        //SceneManager.LoadScene("Start");
        isGameActive = false;
    }
    
    public void RegisterSpawner(EnemySpawner spawner)
    {
        var list = new List<EnemySpawner>(enemySpawners) { spawner };
        enemySpawners = list.ToArray();
    }
    public void UnregisterSpawners()
    {
        enemySpawners = new EnemySpawner[0];
    }

    
}
using UnityEngine;

public class GameManager : MonoBehaviour
{

 
    public GameObject[] enemyPrefabs; 
    public Transform[] spawnPoints;  
    public Transform player;

    // Mode control (0: MultipleAgents, 1: Multi_Agent, 2: AdvancedMultiAgent)
    public int currentMode = 0; 

    private GameObject[] currentEnemies; 

    void Start()
    {


        SpawnWave();
    }

    void Update()
    {

        // Switch to Multiple Agents
        if (Input.GetKeyDown(KeyCode.Alpha1))  
        {

            SwitchMode(0);
        }

        // Switch to Multi-Agent
        if (Input.GetKeyDown(KeyCode.Alpha2))  
        {

            SwitchMode(1);
        }

        // Switch to Advanced Multi-Agent
        if (Input.GetKeyDown(KeyCode.Alpha3))  
        {

            SwitchMode(2);
        }


    }


    void SpawnWave()
    {

        // Destroy all existing enemies
        if (currentEnemies != null)
        {

            foreach (GameObject enemy in currentEnemies)
            {

                if (enemy != null)
                {

                    Destroy(enemy);
                }

            }


        }

        // Reset enemey
        currentEnemies = new GameObject[spawnPoints.Length];

        
        for (int i = 0; i < spawnPoints.Length; i++)
        {

            if (spawnPoints[i] == null)
            {

                Debug.LogError("null spawn");
                continue;
            }

            // Instantiate enemy based on current mode
            GameObject enemy = Instantiate(enemyPrefabs[0], spawnPoints[i].position, Quaternion.identity);
            currentEnemies[i] = enemy;

          
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

            if (enemyMovement != null)
            {

                enemyMovement.player = player;
            }

            // Attach AI script based on mode
            switch (currentMode)
            {

                case 0:

                    // Multiple Agents
                    enemy.AddComponent<MultipleAgents>().player = player;
                    break;
                case 1:

                    // Multi-Agent
                    enemy.AddComponent<Multi_Agent>().player = player;
                    break;
                case 2:

                    // Advanced Multi-Agent
                    enemy.AddComponent<AdvancedMultiAgent>().player = player;
                    break;

                default:
                    Debug.LogError("Invalid currentMode value: " + currentMode);
                    break;
            }

        }

    }

    
    public void SwitchMode(int mode)
    {

        if (mode >= 0 && mode <= 2)
        {

            currentMode = mode;
            Debug.Log("Switched to mode: " + currentMode);

            // Spawn new enemies with the selected AI logic
            SpawnWave();
        }

        else
        {

            Debug.LogError("Invalid mode: " + mode);
        }

    }


}

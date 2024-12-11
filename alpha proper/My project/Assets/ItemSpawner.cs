using UnityEngine;

public class DynamicSpawner : MonoBehaviour
{
    public GameObject[] spawners; // Array of spawners
    public GameObject fallingItemPrefab; // The prefab to spawn
    public float initialSpawnInterval = 2f; // Initial interval between spawns
    public float minimumSpawnInterval = 0.5f; // Minimum interval for spawning
    public float difficultyIncreaseRate = 0.1f; // How much to decrease the interval over time

    private float[] spawnTimers; // Individual timers for each spawner
    private float globalSpawnInterval; // Current global spawn interval

    void Start()
    {
        // Initialize timers for each spawner
        spawnTimers = new float[spawners.Length];
        globalSpawnInterval = initialSpawnInterval;

        // Set random initial spawn timers for each spawner
        for (int i = 0; i < spawnTimers.Length; i++)
        {
            spawnTimers[i] = Random.Range(0f, globalSpawnInterval);
        }
    }

    void Update()
    {
        // Update timers for each spawner
        for (int i = 0; i < spawners.Length; i++)
        {
            spawnTimers[i] -= Time.deltaTime;

            // Check if the timer has expired
            if (spawnTimers[i] <= 0f)
            {
                SpawnItem(spawners[i]);
                spawnTimers[i] = globalSpawnInterval + Random.Range(-0.1f, 0.1f); // Slight randomization
            }
        }

        // Gradually decrease the global spawn interval over time
        if (globalSpawnInterval > minimumSpawnInterval)
        {
            globalSpawnInterval -= difficultyIncreaseRate * Time.deltaTime;
        }
    }

    void SpawnItem(GameObject spawner)
    {
        // Spawn the falling item at the spawner's position
        Instantiate(fallingItemPrefab, spawner.transform.position, Quaternion.identity);
    }
}

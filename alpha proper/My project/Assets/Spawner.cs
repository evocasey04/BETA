using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject[] platformPrefabs; // Array of platform prefabs to spawn
    public Transform player; // Reference to the player's transform
    public float platformSpawnInterval = 20f; // Horizontal distance between platforms
    public float despawnDistance = 20f; // Distance behind the player to destroy objects

    private float nextSpawnPoint; // The X position where the next platform will spawn

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned in the Inspector!");
            return;
        }

        // Initialize the next spawn point to the first interval
        nextSpawnPoint = player.position.x + platformSpawnInterval;

        // Spawn the first platform at the starting position
        SpawnInitialPlatform();
    }

    void Update()
    {
        if (player == null) return;

        // Spawn a new platform when the player reaches the next spawn point
        if (player.position.x >= nextSpawnPoint)
        {
            SpawnPlatform();
        }

        // Remove old objects that are behind the player
        DespawnObjects();
    }

    void SpawnPlatform()
    {
        if (platformPrefabs.Length == 0)
        {
            Debug.LogError("No platform prefabs assigned!");
            return;
        }

        // Choose a random platform prefab
        GameObject platform = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

        // Determine the spawn position for the platform
        Vector3 spawnPosition = new Vector3(nextSpawnPoint, 0, 0);

        // Instantiate the platform
        GameObject spawnedPlatform = Instantiate(platform, spawnPosition, Quaternion.identity);
        spawnedPlatform.tag = "SpawnedObject";

        // Update the next spawn point
        nextSpawnPoint += platformSpawnInterval;
    }

    void SpawnInitialPlatform()
    {
        if (platformPrefabs.Length == 0)
        {
            Debug.LogError("No platform prefabs assigned!");
            return;
        }

        // Spawn the first platform at the player's starting position
        Vector3 spawnPosition = new Vector3(player.position.x, 0, 0);
        GameObject spawnedPlatform = Instantiate(platformPrefabs[0], spawnPosition, Quaternion.identity);
        spawnedPlatform.tag = "SpawnedObject";
    }

    void DespawnObjects()
    {
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");

        foreach (GameObject obj in spawnedObjects)
        {
            // Destroy objects that are far behind the player
            if (obj.transform.position.x < player.position.x - despawnDistance)
            {
                Destroy(obj);
            }
        }
    }
}

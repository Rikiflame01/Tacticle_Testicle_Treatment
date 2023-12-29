using UnityEngine;
using System.Collections;

public class BossMechanics : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign the prefab in the inspector
    public Transform[] spawnPoints; // Assign spawn points in the inspector
    public float spawnInterval = 15f; // Time interval between spawns

    private void Start()
    {
        StartCoroutine(SpawnPrefabRoutine());
    }

    private IEnumerator SpawnPrefabRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned to BossMechanics.");
            return;
        }

        // Randomly select a spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        // Instantiate the prefab at the chosen spawn point
        Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}

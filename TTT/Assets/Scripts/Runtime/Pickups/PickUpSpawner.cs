using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject healthPickupPrefab;
    public GameObject shieldPickupPrefab;
    public GameObject QuizSpawnPrefab;

    private void Start()
    {
        EnemyDeathActions.OnDeath += SpawnPickup;
    }

    private void OnDestroy()
    {
        EnemyDeathActions.OnDeath -= SpawnPickup;
    }

    private void SpawnPickup(Vector3 position)
    {
        GameObject pickupPrefab;
        float randomValue = Random.value;
        if (randomValue >= 0.8f)
            pickupPrefab = QuizSpawnPrefab;
        else if (randomValue >= 0.4f)
            pickupPrefab = healthPickupPrefab;
        else
            pickupPrefab = shieldPickupPrefab;

        GameObject spawnedPickup = Instantiate(pickupPrefab, position, Quaternion.identity);

        // Adjust rotation for shield prefab
        if (pickupPrefab == shieldPickupPrefab)
        {
            spawnedPickup.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0)); // Adjust the rotation values as needed
        }

        if (pickupPrefab == QuizSpawnPrefab)
        {
            StartCoroutine(DespawnAfterDelay(spawnedPickup, 10f)); // Despawn quiz pickup after 10 seconds
        }
    }

    private IEnumerator DespawnAfterDelay(GameObject pickup, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (pickup != null) // Check if the pickup is still present
        {
            Destroy(pickup); // Destroy the pickup
        }
    }

}
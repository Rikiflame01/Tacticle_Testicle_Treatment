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

        Instantiate(pickupPrefab, position, Quaternion.identity);
    }
}
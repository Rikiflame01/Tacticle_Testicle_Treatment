using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject healthPickupPrefab;
    public GameObject shieldPickupPrefab;

    void Start()
    {
        EnemyDeathActions.OnDeath += SpawnPickup;
    }

    void OnDestroy()
    {
        EnemyDeathActions.OnDeath -= SpawnPickup;
    }

    void SpawnPickup(Vector3 position)
    {
        GameObject pickupPrefab = Random.value > 0.5f ? healthPickupPrefab : shieldPickupPrefab;
        Instantiate(pickupPrefab, position, Quaternion.identity);
    }
}
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;
    public GameObject specialEnemyPrefab;

    private const int MELEE_COUNT = 5;
    private const int RANGED_COUNT = 1;
    private const int SPECIAL_COUNT = 1;
    private const float SPAWN_DELAY = 10f; // Adjust this value as needed

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return StartCoroutine(SpawnWithDelay(meleeEnemyPrefab, MELEE_COUNT));
        yield return StartCoroutine(SpawnWithDelay(rangedEnemyPrefab, RANGED_COUNT));
        yield return StartCoroutine(SpawnWithDelay(specialEnemyPrefab, SPECIAL_COUNT));
    }

    IEnumerator SpawnWithDelay(GameObject enemyPrefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(SPAWN_DELAY);
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemyController enemyController = enemyInstance.GetComponent<EnemyController>();

        if (enemyController)
        {
            enemyController.patrolPoints = GetPatrolPoints();
        }
    }

    Transform[] GetPatrolPoints()
    {
        // Assuming you won't have more than 100 patrol points for a spawn point
        Transform[] points = new Transform[100];
        int count = 0;

        for (int i = 1; i <= 100; i++)
        {
            Transform point = transform.Find($"SpawnPoint{transform.GetSiblingIndex() + 1}PP{i}");
            if (point)
            {
                points[count] = point;
                count++;
            }
            else
            {
                break; // Exit the loop if a patrol point is not found
            }
        }

        System.Array.Resize(ref points, count);
        return points;
    }
}

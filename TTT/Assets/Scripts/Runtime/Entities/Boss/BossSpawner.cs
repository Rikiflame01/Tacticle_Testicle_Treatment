using UnityEngine;
using System.Collections;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 10f;
    public bool bossSpawned = false;

    private void Start()
    {
        StartCoroutine(SpawnBossAfterDelay());
    }

    private IEnumerator SpawnBossAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnBoss();
    }

    public void SpawnBoss()
    {
        if (!bossSpawned && bossPrefab != null && spawnPoint != null)
        {
            Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
            bossSpawned = true;

            MusicManager musicManager = FindObjectOfType<MusicManager>();
            if (musicManager != null)
            {
                musicManager.PlayBossMusic();
            }
        }
    }
}

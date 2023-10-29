using TMPro;
using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    public int TotalEnemyCount { get; private set; }
    public TextMeshProUGUI enemyCountText;  // Reference to the TextMeshPro text

    private float refreshInterval = 30f;  // Time in seconds to refresh the enemy count

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(RefreshEnemyCountPeriodically());
    }

    private IEnumerator RefreshEnemyCountPeriodically()
    {
        while (true)
        {
            UpdateEnemyCount();
            yield return new WaitForSeconds(refreshInterval);
        }
    }

    public void UpdateEnemyCount()
    {
        TotalEnemyCount = GameObject.FindGameObjectsWithTag("MeleeEnemy").Length +
                          GameObject.FindGameObjectsWithTag("RangedEnemy").Length +
                          GameObject.FindGameObjectsWithTag("SpecialEnemy").Length +
                          GameObject.FindGameObjectsWithTag("Boss").Length;

        // Update the TextMeshPro text
        if (enemyCountText != null)
        {
            enemyCountText.text = ""+TotalEnemyCount;
        }
    }
}

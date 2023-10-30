using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TesticlePortalTrigger : MonoBehaviour
{
    public UnityEvent onBossTriggered;

    private int enemyCount;
    private bool bossTriggered;

    private void Start()
    {
        enemyCount = 0;
        bossTriggered = false;
        StartCoroutine(CheckEnemies());
        Debug.Log("Script is running");
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("MeleeEnemy").Length +
                     GameObject.FindGameObjectsWithTag("SpecialEnemy").Length +
                     GameObject.FindGameObjectsWithTag("RangedEnemy").Length;
    }

    private IEnumerator CheckEnemies()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(120f); // Wait for 2 minutes before starting the check
        Debug.Log("2 minutes are up!");
        while (true)
        {
            if (enemyCount == 0 && !bossTriggered)
            {
                TriggerBossEvent();
                bossTriggered = true;
                break; // Exit the loop if the boss event is triggered
            }
            else
            {
                yield return new WaitForSeconds(5f); // Wait for 5 seconds before checking again
            }
        }
    }

    private void TriggerBossEvent()
    {
        onBossTriggered.Invoke();
        Debug.Log("Boss event triggered!");
    }
}

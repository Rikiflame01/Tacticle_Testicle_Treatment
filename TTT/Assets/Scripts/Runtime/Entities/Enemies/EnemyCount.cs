using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnEnable()
    {
        EnemyManager.Instance.UpdateEnemyCount();
    }

    private void OnDestroy()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.UpdateEnemyCount();
        }
    }
}

using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public GameObject particleEffectPrefab; // Assign this in the inspector

    private void OnEnable()
    {
        EnemyDeathActions.OnDeath += HandleEnemyDeath;
    }

    private void OnDisable()
    {
        EnemyDeathActions.OnDeath -= HandleEnemyDeath;
    }

    private void HandleEnemyDeath(Vector3 deathPosition)
    {
        if (gameObject.tag == "MeleeEnemy")
        {
            Instantiate(particleEffectPrefab, deathPosition, Quaternion.identity);
            SFXManager.Instance.PlaySFX(SFXManager.Instance.ConfettiCannon);
        }
        
    }
}

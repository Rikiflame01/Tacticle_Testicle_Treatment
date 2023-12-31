using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeathActions : MonoBehaviour
{
    public static event System.Action<Vector3> OnDeath;
    private HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.OnDied.AddListener(HandleDeath);
        }
    }

    private void OnDestroy()
    {
        if (healthComponent != null)
        {
            healthComponent.OnDied.RemoveListener(HandleDeath);
        }
    }

    private void HandleDeath()
    {
        OnDeath?.Invoke(transform.position);

        var bossAttackComponent = GetComponent<BossAttack>();
        if (bossAttackComponent != null)
        {
            Debug.Log("BossAttack component found.");
            StartCoroutine(LoadWinScreenAfterDelay());
        }
        else
        {
            Debug.Log("BossAttack component not found.");
            Destroy(gameObject);
        }
    }

    private IEnumerator LoadWinScreenAfterDelay(float delay = 1f)
    {
        yield return new WaitForSeconds(delay);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("WinScreen");
        Destroy(gameObject);
    }
}

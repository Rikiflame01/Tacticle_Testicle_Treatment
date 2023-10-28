using TTT;
using UnityEngine;

public class FPS_Shooting : MonoBehaviour
{
    public AmmoSO ammoSO;
    public Transform gunMuzzle;
    public GameObject bulletPrefab;
    public float shootingForce = 1000f;
    private bool isPaused = false;

    private void OnEnable()
    {
        GameEvents.OnGamePaused += Pause;
        GameEvents.OnGameResumed += Resume;
    }

    private void OnDisable()
    {
        GameEvents.OnGamePaused -= Pause;
        GameEvents.OnGameResumed -= Resume;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isPaused)  // Check if game is not paused
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!ammoSO.fire())
        {
            return;
        }
        else
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.shooting);
            GameObject tmpBullet = Instantiate(ammoSO.getBulletPrefab(), gunMuzzle.position, gunMuzzle.rotation);
        }

        SFXManager.Instance.PlaySFX(SFXManager.Instance.shooting);
        GameObject bullet = Instantiate(bulletPrefab, gunMuzzle.position, gunMuzzle.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        Vector3 horizontalDirection = new Vector3(gunMuzzle.forward.x, 0, gunMuzzle.forward.z).normalized;
        bulletRb.AddForce(horizontalDirection * shootingForce);

        Destroy(bullet, 5f);
    }

    private void Pause()
    {
        isPaused = true;
    }

    private void Resume()
    {
        isPaused = false;
    }
}
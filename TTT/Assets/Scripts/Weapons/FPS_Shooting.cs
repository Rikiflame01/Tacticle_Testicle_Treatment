using UnityEngine;

public class FPS_Shooting : MonoBehaviour
{
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

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isPaused)  // Check if game is not paused
        {
            Shoot();
        }
    }

    void Shoot()
    {
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

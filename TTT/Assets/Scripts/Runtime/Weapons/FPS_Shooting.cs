using UnityEngine;
using TTT;

public class FPS_Shooting : MonoBehaviour
{
    public AmmoSO ammoSO;
    public Transform gunMuzzle;
    public GameObject bulletPrefab;
    public float shootingForce = 5000f;
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
        BulletTypeSO currentBulletType = ammoSO.CurrentBulletTypes[ammoSO.getCurrentBulletTypeIndex()];

        if (!currentBulletType.CanFire() || !ammoSO.fire())
        {
            return;
        }

        GameObject tmpBullet = Instantiate(currentBulletType.getBulletPrefab(), gunMuzzle.position, gunMuzzle.rotation);
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
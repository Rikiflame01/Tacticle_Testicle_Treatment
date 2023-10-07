using UnityEngine;

public class FPS_Shooting : MonoBehaviour
{
    public Transform gunMuzzle;

    public GameObject bulletPrefab;

    public float shootingForce = 1000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
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
}

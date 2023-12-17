using UnityEngine;

namespace TTT
{
    public class Ricochet_BulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        private Rigidbody _bulletRb;
        public float damage = 10f;
        public float shootingForce = 1000f;
        public float bulletLifeTime = 5f;
        public int numberOfBounces = 4;
        public float minimumSpeed = 10f; // Minimum speed to maintain after ricochet
        private Vector3 lastVel;
        private int currBounces = 0;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            _bulletRb = GetComponent<Rigidbody>();

            PlayInitialSound();

            Vector3 shootingDirection = transform.forward.normalized;
            _bulletRb.AddForce(shootingDirection * shootingForce, ForceMode.VelocityChange);

            Destroy(gameObject, bulletLifeTime);
        }

        private void LateUpdate()
        {
            lastVel = _bulletRb.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            PlayCollisionSound(collision);
            ApplyDamage(collision);

            if (currBounces < numberOfBounces)
            {
                Ricochet(collision);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion UNITY METHODS

        #region PRIVATE METHODS

        private void PlayInitialSound()
        {
            try
            {
                SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive, 2);
            }
            catch (System.Exception e)
            {
                Debug.Log("Initial Sound Error: " + e);
            }
        }

        private void PlayCollisionSound(Collision collision)
        {
            string tag = collision.gameObject.tag;
            try
            {
                if (tag == "Boss" || tag == "MeleeEnemy" || tag == "RangedEnemy" || tag == "SpecialEnemy")
                {
                    SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 2);
                }
                else
                {
                    SFXManager.Instance.PlaySFX(SFXManager.Instance.projectileCollision, 2);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("Collision Sound Error: " + e);
            }
        }

        private void ApplyDamage(Collision collision)
        {
            if (collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("MeleeEnemy") ||
                collision.gameObject.CompareTag("RangedEnemy") || collision.gameObject.CompareTag("SpecialEnemy"))
            {
                HealthComponent enemyHealth = collision.gameObject.GetComponent<HealthComponent>();
                if (enemyHealth)
                {
                    enemyHealth.TakeDamage((int)damage);
                }
            }
        }

        private void Ricochet(Collision collision)
        {
            Vector3 incomingVec = lastVel.normalized;
            Vector3 normal = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomingVec, normal);

            // Apply a slight random deviation on near-perpendicular collision
            if (Vector3.Angle(incomingVec, normal) < 10f || Vector3.Angle(incomingVec, normal) > 170f)
            {
                reflectVec = Quaternion.Euler(0, Random.Range(-10f, 10f), Random.Range(-10f, 10f)) * reflectVec;
            }

            _bulletRb.velocity = reflectVec * Mathf.Max(lastVel.magnitude, minimumSpeed);
            currBounces++;
        }

        #endregion PRIVATE METHODS
    }
}

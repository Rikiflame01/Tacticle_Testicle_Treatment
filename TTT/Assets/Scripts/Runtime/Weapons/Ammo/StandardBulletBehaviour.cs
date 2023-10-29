using UnityEngine;

namespace TTT
{
    public class StandardBulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        public float shootingForce = 1000f;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            Rigidbody bulletRb = this.GetComponent<Rigidbody>();

            Vector3 horizontalDirection = this.transform.forward.normalized;
            bulletRb.AddForce(horizontalDirection * shootingForce);

            Destroy(this, 5f);
        }

        #endregion UNITY METHODS
    }
}
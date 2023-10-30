using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    public class Laser_BulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        private LineRenderer _Beam;
        public float BeamDuration = 0.1f;
        public int Damage = 50;
        public Color LaserColor = Color.red;
        public float BeamMaxLen = 100f;
        public float BeamWidth = 0.1f;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.shooting);
            _Beam = GetComponent<LineRenderer>();
            _Beam.useWorldSpace = true;
            _Beam.enabled = true;
            _Beam.material.color = LaserColor;
            _Beam.widthMultiplier = BeamWidth;
            _Beam.SetPosition(0, transform.position);
            StartCoroutine(Laz());
        }

        #endregion UNITY METHODS

        #region METHODS

        private IEnumerator Laz()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, BeamMaxLen))
            {
                _Beam.SetPosition(1, hit.point);
                if (hit.collider.gameObject.CompareTag("Boss"))
                {
                    SFXManager.Instance.PlaySFX(SFXManager.Instance.bossDamage, 3);
                    hit.collider.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
                }
                if (hit.collider.gameObject.CompareTag("MeleeEnemy"))
                {
                    SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
                    hit.collider.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
                }
                if (hit.collider.gameObject.CompareTag("RangedEnemy"))
                {
                    SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
                    hit.collider.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
                }
                if (hit.collider.gameObject.CompareTag("SpecialEnemy"))
                {
                    SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
                    hit.collider.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
                }
                else
                {
                    SFXManager.Instance.PlaySFX(SFXManager.Instance.projectileCollision, 2);
                }
            }
            else
            {
                _Beam.SetPosition(1, transform.position + (transform.forward * BeamMaxLen));
            }
            yield return null;
            StartCoroutine(BeamDurationTimer());
        }

        private IEnumerator FadeOutBeam()
        {
            while (_Beam.enabled)
            {
                float alpha = 1f;
                while (alpha > 0f)
                {
                    alpha -= Time.deltaTime;
                    _Beam.material.color = new Color(1f, 1f, 1f, alpha);
                    yield return null;
                }
                _Beam.enabled = false;
            }
        }

        private IEnumerator BeamDurationTimer()
        {
            yield return new WaitForSeconds(BeamDuration);
            StartCoroutine(FadeOutBeam());
            StartCoroutine(DestroyBeam());
        }

        private IEnumerator DestroyBeam()
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }

        #endregion METHODS
    }
}
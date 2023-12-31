using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed = 10f;
    private Transform target;
    private Rigidbody rb;

    public void Initialize(int damage, Transform target)
    {
        this.damage = damage;
        this.target = target;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity

        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * speed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Target not set for projectile.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == target)
        {
            Debug.Log("Projectile hit target.");
            HealthComponent targetHealth = target.GetComponent<HealthComponent>();
            if (targetHealth)
            {
                targetHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}

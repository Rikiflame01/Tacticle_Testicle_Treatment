// PickupFloating.cs
using UnityEngine;

public class PickupFloating : MonoBehaviour
{
    public float floatSpeed = 1f; // Speed at which the pickup will float up and down
    public float floatHeight = 0.5f; // Height the pickup will float
    public float rotationSpeed = 45f; // Speed at which the pickup will rotate
    public float initialRiseHeight = 0.5f; // Height the pickup will initially rise to
    public float initialRiseSpeed = 1f; // Speed at which the pickup will initially rise

    private Vector3 initialPosition;
    private bool isRising = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isRising)
        {
            Rise();
        }
        else
        {
            Float();
        }
        Rotate();
    }

    void Rise()
    {
        float newY = transform.position.y + (initialRiseSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Check if the pickup has risen to the desired height
        if (transform.position.y >= initialPosition.y + initialRiseHeight)
        {
            isRising = false;
            // Update the initial position for floating
            initialPosition = transform.position;
        }
    }

    void Float()
    {
        float newY = initialPosition.y + (Mathf.Sin(Time.time * floatSpeed) * floatHeight);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}

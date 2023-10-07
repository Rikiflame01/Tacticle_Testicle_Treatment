using UnityEngine;

public class MeleeEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 20f; // Speed at which the enemy moves towards the player

    private Transform player; // Reference to the player's transform

    private void Start()
    {
        // Automatically find the player object using the "Player" tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        // If a player object is found, rotate and move towards it
        if (player)
        {
            // Rotate the enemy to face the player
            FacePlayer();

            // Move the enemy towards the player
            MoveTowardsPlayer();
        }
    }

    void FacePlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Calculate the rotation needed to face the player
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Apply the rotation to the enemy
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction to move in
        Vector3 moveDirection = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}

using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; 
    public Vector3 offset;  

    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x + offset.x, transform.position.y, playerTransform.position.z + offset.z);
        }
    }
}

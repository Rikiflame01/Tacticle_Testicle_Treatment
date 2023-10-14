using UnityEngine;

public static class Sight
{
    public static bool IsPlayerInSight(Transform eyeOrigin, Transform player, float sightRange)
    {
        RaycastHit hit;
        Vector3 directionToPlayer = (player.position - eyeOrigin.position).normalized;

        // Draw a debug ray in the Scene view
        Debug.DrawRay(eyeOrigin.position, directionToPlayer * sightRange, Color.red, 2f);

        if (Physics.Raycast(eyeOrigin.position, directionToPlayer, out hit, sightRange))
        {
            return hit.transform.CompareTag("Player");
        }

        return false;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Extract the level name from the portal's name
            string levelName = ExtractLevelName(gameObject.name);

            // If a valid level name is extracted, load that level
            if (!string.IsNullOrEmpty(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("Invalid portal name. Cannot determine the level to load.");
            }
        }
    }

    // This function extracts the level name from the portal's name
    private string ExtractLevelName(string portalName)
    {
        if (portalName.Contains("Portal"))
        {
            return portalName.Replace("Portal", "");
        }
        return string.Empty;
    }
}

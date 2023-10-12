using UnityEngine;

public class UIPlayerDeath : MonoBehaviour
{
    public GameObject deathScreenPanel; // Reference to the death screen panel

    public void ShowDeathScreen()
    {
        deathScreenPanel.SetActive(true);

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetryGame()
    {
        // For example, to reload the current scene:
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        // Lock the cursor again for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SwitchScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement; // Required for accessing scene information

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float sensitivityX = 8f;
    [SerializeField] private float sensitivityY = 0.5f;
    [SerializeField] private float xClamp = 85f;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

    private void Start()
    {
        SetCursorState();
    }

    private void SetCursorState()
    {
        // Get the current active scene's name
        string currentScene = SceneManager.GetActiveScene().name;

        // If the current scene is "GameScene" or "MainMenu", unlock the cursor
        if (currentScene == "GameScene" || currentScene == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ReceiveInput(Vector2 _mouseInput)
    {
        mouseX = _mouseInput.x * sensitivityX;
        mouseY = _mouseInput.y * sensitivityY;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
}

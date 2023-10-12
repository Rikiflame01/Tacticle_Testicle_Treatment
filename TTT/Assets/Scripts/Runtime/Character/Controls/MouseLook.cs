using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float sensitivityX = 8f;
    [SerializeField] private float xClamp = 85f;
    private float mouseX;
    private bool isPaused = false;

    private void Start()
    {
        SetCursorState();
        GameEvents.OnGamePaused += Pause;

        GameEvents.OnGameResumed += Resume;
    }

    private void OnDestroy()
    {
        GameEvents.OnGamePaused -= Pause;
        GameEvents.OnGameResumed -= Resume;
    }

    private void SetCursorState()
    {
        string currentScene = SceneManager.GetActiveScene().name;
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
    }

    private void Update()
    {
        if (isPaused)
            return;

        transform.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }

    private void Pause()
    {
        isPaused = true;
    }

    private void Resume()
    {
        isPaused = false;
    }
}

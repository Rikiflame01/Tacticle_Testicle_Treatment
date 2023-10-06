using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float sensitivityX = 8f;
    [SerializeField] private float sensitivityY = 0.5f;
    [SerializeField] private float xClamp = 85f;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

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

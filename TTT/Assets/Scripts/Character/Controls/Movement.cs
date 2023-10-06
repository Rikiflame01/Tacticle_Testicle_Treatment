using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 200f;
    [SerializeField] private float gravity = -30f;
    [SerializeField] private float jumpHeight = 3.5f;
    private Vector3 verticalVelocity;
    private Vector2 horizontalInput;
    private bool jump;

    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    private void Update()
    {
        Vector3 horizontalVelocity = transform.right * horizontalInput.x + transform.forward * horizontalInput.y;
        horizontalVelocity *= speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump && controller.isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
        jump = false;
    }

    public void OnJumpPressed()
    {
        jump = true;
    }
}

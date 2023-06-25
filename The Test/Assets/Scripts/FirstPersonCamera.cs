using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform target;  // Reference to the target (capsule) to follow
    public float sensitivity = 2f;  // Mouse look sensitivity
    public Vector2 rotationLimits = new Vector2(-90f, 90f);  // Limits for vertical rotation (up and down)
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);  // Offset from the target's position

    private float rotationX = 0f;  // Current X rotation of the camera

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
    }

    private void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, rotationLimits.x, rotationLimits.y);

        Quaternion horizontalRotation = Quaternion.Euler(0f, mouseX, 0f);
        Quaternion verticalRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.localRotation *= verticalRotation * horizontalRotation;

        // Camera follow
        transform.position = target.position + offset;
    }
}

using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform target;  // Reference to the target (capsule) to follow
    public float sensitivity = 2f;  // Mouse look sensitivity
    public Vector2 rotationLimits = new Vector2(-90f, 90f);  // Limits for vertical rotation (up and down)

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

        target.Rotate(Vector3.up * mouseX);
        transform.localRotation = verticalRotation;

        // Camera follow
        transform.position = target.position + target.TransformDirection(Vector3.up) + target.TransformDirection(Vector3.forward) * 0.1f;  // Adjust the offset as per your preference
    }
}

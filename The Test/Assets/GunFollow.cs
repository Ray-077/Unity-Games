using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunPosition;  // Reference to the predefined gun position

    private void Start()
    {
        // Set the initial position and rotation of the gun
        transform.position = gunPosition.position;
        transform.rotation = gunPosition.rotation;
    }

    private void LateUpdate()
    {
        // Update the gun's position and rotation relative to the predefined position
        transform.position = gunPosition.position;
        transform.rotation = gunPosition.rotation;
    }

    // Other code and methods...
}

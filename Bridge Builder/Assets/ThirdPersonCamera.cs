using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;        // Reference to the player's transform
    public Vector3 offset;          // Offset from the player
    public float rotationSpeed = 5f; // Speed at which the camera rotates

    private Vector3 currentOffset;
    private Quaternion currentRotation;

    private void Start()
    {
        // Initialize the current offset and rotation
        currentOffset = offset;
        currentRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }

    private void LateUpdate()
    {
        // Rotate the camera offset based on the player's rotation
        Quaternion playerRotation = Quaternion.Euler(0, player.eulerAngles.y, 0);
        currentOffset = playerRotation * offset;

        // Update camera position
        transform.position = player.position + currentOffset;

        // Keep the camera facing the player
        transform.LookAt(player);

        // Optional: Smoothly follow the player rotation
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;

        if (Input.GetMouseButton(1)) // Right mouse button for rotating
        {
            currentRotation *= Quaternion.Euler(-vertical, horizontal, 0);
            transform.rotation = currentRotation;
        }
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform player; // The player's Transform to follow

    [Header("Camera Offset")]
    public Vector3 offset = new Vector3(5f, 2f, -10f); // Offset of the camera from the player

    [Header("Smooth Damping")]
    public float smoothSpeed = 0.125f; // How smoothly the camera follows the player

    void LateUpdate()
    {
        if (player == null) return; // If no player is assigned, do nothing

        // Calculate the desired position for the camera
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply the new position to the camera
        transform.position = smoothedPosition;
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float smoothTime = 0.15f;

    private Vector3 velocity = Vector3.zero;

    /// <summary>
    /// Smoothly follows the player after all movement has been applied.
    /// </summary>
    void LateUpdate()
    {
        if (playerPos == null)
            return;

        Vector3 targetPos = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
    }
}
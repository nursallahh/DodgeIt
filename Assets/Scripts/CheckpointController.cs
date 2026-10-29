using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    public static Vector3 playerLastPos;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody playerBody = other.attachedRigidbody;
        if (playerBody != null && playerBody.CompareTag("PlayerObject"))
        {
            playerLastPos = playerBody.position;
        }

    }
}

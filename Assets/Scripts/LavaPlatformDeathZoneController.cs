using UnityEngine;

public class LavaPlatformDeathZoneController : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    
     

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerBody = other.attachedRigidbody;

        if (playerBody == null ||!playerBody.CompareTag("PlayerObject")) return;

        playerBody.position = respawnPoint.position;
        playerBody.linearVelocity = Vector3.zero;
        playerBody.angularVelocity = Vector3.zero;
    }
}

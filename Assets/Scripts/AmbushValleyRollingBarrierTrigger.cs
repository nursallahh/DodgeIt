using Unity.VisualScripting;
using UnityEngine;

public class RollingBarrierTrigger : MonoBehaviour
{
    [SerializeField] GameObject rollingBarrier;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody playerBody = other.attachedRigidbody;
        
        if(playerBody == null || !playerBody.CompareTag("PlayerObject")) return;

        if(rollingBarrier.gameObject == null) return;
        rollingBarrier.SetActive(true);


    }

}

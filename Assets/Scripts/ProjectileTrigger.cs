using Unity.VisualScripting;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{

    [SerializeField] FlyAtPlayer[] projectiles;
    public static Vector3 playerLastPos;

    void OnTriggerEnter(Collider other)
{
    Rigidbody playerBody = other.attachedRigidbody;

        if (playerBody != null && playerBody.CompareTag("PlayerObject"))
        {
            playerLastPos = playerBody.gameObject.transform.position;

            foreach (FlyAtPlayer projectile in projectiles)
            {
                if (projectile != null)
                {
                    projectile.gameObject.SetActive(true);
                }
            }
        }
}

}

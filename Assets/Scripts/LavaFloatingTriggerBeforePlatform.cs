using UnityEngine;

public class LavaFloatingTriggerBeforePlatform : MonoBehaviour
{
    [SerializeField] Transform[] Lava;
    [SerializeField] Vector3[] howMuchLavaWillUp;
    private float LavaFloatingSpeed = 0.05f;
    

    Vector3[] targetPosition;
    bool started;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody playerBody = other.attachedRigidbody;

        if (started || playerBody == null ||
            !playerBody.CompareTag("PlayerObject"))
            return;

        
        targetPosition = new Vector3[Lava.Length];

        for (int i = 0; i < Lava.Length; i++)
        {
            targetPosition[i] = Lava[i].position + howMuchLavaWillUp[i];
        }

        started = true;
    }

    void Update()
    {
        if (!started)
            return;

        for (int i = 0; i < Lava.Length; i++)
        {
            Lava[i].position = Vector3.MoveTowards(
                Lava[i].position,
                targetPosition[i],
                LavaFloatingSpeed * Time.deltaTime
            );
        }
    }
}
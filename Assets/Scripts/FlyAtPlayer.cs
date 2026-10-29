using Unity.VisualScripting;
using UnityEngine;


public class FlyAtPlayer : MonoBehaviour
{
    
    [SerializeField] float speed = 5f;

    void ProjectileFlyTowards()
    {
        transform.position = Vector3.MoveTowards(
        transform.position,
        ProjectileTrigger.playerLastPos,
        speed * Time.deltaTime
        );
    }

    void Destroy()
    {
        if(transform.position == ProjectileTrigger.playerLastPos)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            ProjectileFlyTowards();
        }
        Destroy();
    }

    
}

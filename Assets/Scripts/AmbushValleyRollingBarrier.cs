using Unity.VisualScripting;
using UnityEngine;

public class RollingBarrier : MonoBehaviour
{
    [SerializeField] float rollingSpeed = 3f;
    [SerializeField] float FlyingPosMultiplier = 10f;
    [SerializeField] Vector3 rotatingPos;
    private Vector3 flyingPos = Vector3.zero;
    
    void rollIntoPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position , flyingPos , rollingSpeed * Time.deltaTime); 
        if(transform.position == flyingPos) Destroy(gameObject);
    }

    void Start()
    {
        flyingPos = transform.position + rotatingPos * FlyingPosMultiplier;
    }


    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            rollIntoPlayer();
        }
    }

}

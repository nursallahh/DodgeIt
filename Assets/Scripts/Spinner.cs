using System.Numerics;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private UnityEngine.Vector3 axis = new UnityEngine.Vector3(0 , 1 , 0);
    [SerializeField] float rotateSpeed = 0.5f;



    void Start()
    {
        
    }

    
    
    void Update()
    {
        transform.Rotate(axis , rotateSpeed);
    }
}

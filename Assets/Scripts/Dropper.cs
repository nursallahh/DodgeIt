using Unity.VisualScripting;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] Mover player;
    MeshRenderer meshRenderer;
    Rigidbody rigidBody;

    private void dropperTiming()
    {

        float distanceBetweenDropperAndPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceBetweenDropperAndPlayer < 6.5f)
        {
            meshRenderer.enabled = true;
            rigidBody.useGravity = true;
        }
       
    }

    void Start()
    {
       meshRenderer = GetComponent<MeshRenderer>();
       rigidBody = GetComponent<Rigidbody>();

       meshRenderer.enabled = false;
       rigidBody.useGravity = false;
    }


    void Update()
    {
        dropperTiming();
    }

}

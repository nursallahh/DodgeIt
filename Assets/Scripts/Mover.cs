using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotateSpeed = 10f;
    public bool isWalking = false;

    [Header("Jump Settings")]
    [SerializeField] private float jumpSpeed = 3f;
    [SerializeField] private float groundCheckDistance = 0.2f;

    [Header("Collision & Layer Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask canJumpLayer;
    [SerializeField] private LayerMask obstacleLayer;

    [Header("Physics Private Cache")]
    private Rigidbody rigidbody;
    private UnityEngine.Vector3 Velocity;
    private UnityEngine.Vector3 playerLastPos;
    UnityEngine.Vector3 moveDir;

    [Header("Internal Variables")]
    private float interactDistance = 0.5f;   // artık sadece etkileşim ışını için
    private float bodyRadius = 0.18f;        // gerçek yarıçap 0.198, biraz küçük olmalı
    private bool jumpRequsted = false;
    private bool isGrounded = true;
    private bool isFacingObject = false;     // son yöne atılan ışın bir şeye çarpıyor mu
    private RaycastHit facingHit;            // çarptığı nesne

    // Update is called once per frame
    void Update()
    {
        movementHandling();
        jumpHandling();
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void movementHandling()
{
    float xValue = Input.GetAxisRaw("Horizontal");
    float zValue = Input.GetAxisRaw("Vertical");

    UnityEngine.Vector3 inputVector = new UnityEngine.Vector3(xValue, 0f, zValue);
    moveDir = inputVector.normalized;

    if (moveDir != UnityEngine.Vector3.zero)
    {
        playerLastPos = moveDir;
    }

    isFacingObject = Physics.CapsuleCast(
        transform.position,
        transform.position + UnityEngine.Vector3.up * 0.473f,
        bodyRadius,
        playerLastPos,
        out facingHit,
        interactDistance,
        obstacleLayer,
        QueryTriggerInteraction.Ignore
    );

    float moveDistance = moveSpeed * Time.deltaTime + 0.05f;

        bool cantMove = Physics.CapsuleCast(
            transform.position, 
            transform.position + UnityEngine.Vector3.up * 0.473f, 
            bodyRadius, 
            moveDir,          
            moveDistance,
            obstacleLayer, 
            QueryTriggerInteraction.Ignore
        );

        if (cantMove)
        {
            UnityEngine.Vector3 moveX = new UnityEngine.Vector3(moveDir.x, 0f, 0f);
            UnityEngine.Vector3 moveZ = new UnityEngine.Vector3(0f, 0f, moveDir.z);

            bool cantMoveOnX = Physics.CapsuleCast(
                transform.position, 
                transform.position + UnityEngine.Vector3.up * 0.473f, 
                bodyRadius, 
                moveX.normalized, 
                moveDistance,     
                obstacleLayer, 
                QueryTriggerInteraction.Ignore
            );

            if (!cantMoveOnX && moveX != UnityEngine.Vector3.zero)
            {
                moveDir = moveX.normalized;
            }
            else
            {
                bool cantMoveOnZ = Physics.CapsuleCast(
                    transform.position, 
                    transform.position + UnityEngine.Vector3.up * 0.473f, 
                    bodyRadius, 
                    moveZ.normalized, 
                    moveDistance,     // DEĞİŞTİ
                    obstacleLayer, 
                    QueryTriggerInteraction.Ignore
                );

                if (!cantMoveOnZ && moveZ != UnityEngine.Vector3.zero)
                {
                    moveDir = moveZ.normalized;
                    // SİLİNDİ: playerLastPos = moveDir;
                }
                else
                {
                    moveDir = UnityEngine.Vector3.zero;
                }
            }
        }

        if (moveDir != UnityEngine.Vector3.zero && inputVector != UnityEngine.Vector3.zero)
        {
            UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(moveDir.normalized) * UnityEngine.Quaternion.Euler(0f, -90, 0f);
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    

    if (moveDir != UnityEngine.Vector3.zero)
    {
        moveDir = moveDir.normalized;
    }

    isWalking = moveDir.z != 0f || moveDir.x != 0f;
 
    rigidbody.linearVelocity = new UnityEngine.Vector3(
        moveDir.x * moveSpeed, 
        rigidbody.linearVelocity.y, 
        moveDir.z * moveSpeed
    );

    Velocity = rigidbody.linearVelocity;
}


    private void jumpHandling()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequsted = true;
        }

        isGrounded = Physics.Raycast(
            groundCheck.position + UnityEngine.Vector3.up * 0.1f,
            UnityEngine.Vector3.down, 
            out RaycastHit hit, 
            groundCheckDistance, 
            canJumpLayer, 
            QueryTriggerInteraction.Ignore
        ) && UnityEngine.Vector3.Angle(hit.normal, UnityEngine.Vector3.up) <= 45f;

        if (jumpRequsted && isGrounded)
        {
            Velocity.y = jumpSpeed;
            rigidbody.linearVelocity = Velocity;   
        }

        jumpRequsted = false;
        
    }
}
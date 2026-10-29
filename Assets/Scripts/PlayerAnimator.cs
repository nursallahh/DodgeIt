using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Mover player;
    UnityEngine.Animator animator;
    private string isWalking = "isWalking";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool(isWalking, player.isWalking);
    }
}
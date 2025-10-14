using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private bool isActive = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>(); // animation is on child
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            isActive = true;
            if (animator != null)
                animator.SetTrigger("Activate"); // trigger your animation

            // Save this checkpoint position
            RespawnManager.instance.SetCheckpoint(transform.position);
        }
    }
}

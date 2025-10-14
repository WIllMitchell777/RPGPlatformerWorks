using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 currentCheckpointPosition;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        // Optionally set an initial spawn point
        currentCheckpointPosition = transform.position;
    }

    public void Respawn()
    {
        playerHealth.Respawn();
        transform.position = currentCheckpointPosition;
        GetComponent<PlayerMovement>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpointPosition = collision.transform.position;

            Animator anim = collision.GetComponentInChildren<Animator>();
            if (anim != null)
            {
                Debug.Log("Triggering appear animation");
                anim.SetTrigger("Appear");
            }

            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}

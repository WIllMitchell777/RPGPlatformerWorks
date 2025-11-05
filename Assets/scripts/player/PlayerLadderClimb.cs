using UnityEngine;

public class PlayerLadderClimb : MonoBehaviour
{
    [SerializeField] private float climbSpeed = 3f;
    [SerializeField] private Rigidbody2D rb;
    private bool isClimbing = false;
    private float vertical;

    private float defaultGravity;

    private void Start()
    {

        
        defaultGravity = rb.gravityScale;
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isClimbing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * climbSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0f; 
            rb.linearVelocity = Vector2.zero; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isClimbing = false;
            rb.gravityScale = defaultGravity; 
        }
    }
}

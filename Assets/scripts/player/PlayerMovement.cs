using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator Anim;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(2, 2, 2);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2, 2, 2);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();

            if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
                SoundManager.instance.PlaySound(jumpSound);
        }
            
            
        Anim.SetBool("run", horizontalInput != 0);
        Anim.SetBool("grounded", isGrounded());

    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        Anim.SetTrigger("jump");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
           
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

}


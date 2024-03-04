using UnityEngine;

public class JumpController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpPower = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.15f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }
}

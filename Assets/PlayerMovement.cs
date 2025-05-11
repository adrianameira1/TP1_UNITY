using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Rigidbody2D rb;
    private Animator anim;
    private bool gravityFlipped = false;
    private bool isGrounded = true;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Ativa a animação de corrida
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("isGrounded", isGrounded);

        // Saltar
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)  // Podes mudar para Space se quiseres
        {
            rb.AddForce(Vector2.up * (gravityFlipped ? -jumpForce : jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }

        // Inverter gravidade com espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlipGravity();
        }
    }

    void FlipGravity()
    {
        gravityFlipped = !gravityFlipped;
        rb.gravityScale *= -1;

        // Inverter visual
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}

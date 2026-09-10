using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 8f;

    public ParticleSystem polvoSalto; // NUEVO

    private Rigidbody2D rb;
    private Animator animator;

    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento izquierda y derecha
        float movimiento = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            movimiento * velocidad,
            rb.linearVelocity.y
        );

        // Animación correr
        if (animator != null)
        {
            animator.SetBool("isRunning", movimiento != 0);
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );

            // Activar polvo
            if (polvoSalto != null)
            {
                polvoSalto.Play();
            }

            enSuelo = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Platform"))
        {
            enSuelo = true;

            if (animator != null)
            {
                animator.SetBool("isJumping", false);
            }
        }
    }
}
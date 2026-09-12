using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 8f;

    public ParticleSystem polvoSalto;

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
        float movimiento = Input.GetAxisRaw("Horizontal");


        // Movimiento
        rb.linearVelocity = new Vector2(
            movimiento * velocidad,
            rb.linearVelocity.y
        );


        // Idle y Run
        animator.SetBool("isRunning", movimiento != 0);


        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );

            enSuelo = false;

            animator.SetBool("isJumping", true);


            if (polvoSalto != null)
            {
                polvoSalto.Play();
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
           collision.gameObject.CompareTag("Platform"))
        {
            enSuelo = true;

            animator.SetBool("isJumping", false);
            // Corrección final de animaciones
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private float velocidad = 8f;
    private float movX;
    private bool saltando;
    //private float movY;
    private float fuerzaSalto = 16f;
    //private bool mirandoHaciaDerecha = true;
    private SpriteRenderer spriteRenderer;

    public Animator animator;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform colisionesSuelo;
    [SerializeField] LayerMask mascaraSuelo;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Cogiendo el input
        //float movX = Input.GetAxis("Horizontal");
        movX = Input.GetAxisRaw("Horizontal");
        //movY = Input.GetAxisRaw("Vertical");

        if (tocandoSuelo())
        {
            saltando = false;
        }

        if (Input.GetButton("Jump") && tocandoSuelo())
        {
            saltando = true;
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);

            if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            
            
        }
        
        comprobarCambioLado();
        establecerAnimaciones();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movX * velocidad, rb.velocity.y);
    }

    private bool tocandoSuelo()
    {
        //return Physics2D.OverlapCircle(colisionesSuelo.position, 0.2f, mascaraSuelo);
        return Physics2D.OverlapBox(colisionesSuelo.position, new Vector2(0.95f, 0.1f),
            0, mascaraSuelo);
    }

    public void impulsarSalto(float fuerzaSalto)
    {
        rb.velocity = new Vector2(movX * velocidad, 0f);
        rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        
        saltando = true;
    }


    public void chafar()
    {
        animator.SetLayerWeight(0, 0f);
        animator.SetLayerWeight(1, 1f);
    }
    
    /*public void deschafar()
    {
        animator.SetLayerWeight(0, 1f);
        animator.SetLayerWeight(1, 0f);
    }*/

    public void animarDanio()
    {
        chafar();
    }

    private void comprobarCambioLado()
    {
        /*
        if (mirandoHaciaDerecha && movX < 0f || !mirandoHaciaDerecha && movX > 0f)
        {
            mirandoHaciaDerecha = !mirandoHaciaDerecha;
            Vector3 localScale = transform.localScale;
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        }*/
        if (movX < 0f)
        {
            spriteRenderer.flipX = true;
        } else if (movX > 0f)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void establecerAnimaciones()
    {
        animator.SetFloat("VelY", rb.velocity.y);
        animator.SetBool("VelX", rb.velocity.x != 0f && 
            (rb.velocity.x >= 0.1f || rb.velocity.x <= -0.1f));
        animator.SetBool("Saltando", saltando);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemigoSalto"))
        {
            impulsarSalto(5f);
        }
    }*/
}

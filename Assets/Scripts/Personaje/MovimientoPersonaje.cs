using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private float velocidad = 8f;
    private float horizontal;
    private float fuerzaSalto = 16f;
    private bool mirandoHaciaDerecha = true;

    public Animator animator;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform colisionesSuelo;
    [SerializeField] LayerMask mascaraSuelo;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump") && tocandoSuelo())
        {
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
        rb.velocity = new Vector2(horizontal * velocidad, rb.velocity.y);
    }

    private bool tocandoSuelo()
    {
        return Physics2D.OverlapCircle(colisionesSuelo.position, 0.2f, mascaraSuelo);
    }

    private void comprobarCambioLado()
    {
        if (mirandoHaciaDerecha && horizontal < 0f || !mirandoHaciaDerecha && horizontal > 0f)
        {
            mirandoHaciaDerecha = !mirandoHaciaDerecha;
            Vector3 localScale = transform.localScale;
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        }
    }

    private void establecerAnimaciones()
    {
        animator.SetFloat("VelY", rb.velocity.y);
        animator.SetBool("VelX", rb.velocity.y != 0f);
    }
}

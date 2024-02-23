using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovimiento : MonoBehaviour
{
    [SerializeField] GameObject goomba;
    bool mirandoIzquierda = true;
    Rigidbody2D rb;
    public Animator animator;
    public float velocidad = 2f;

    bool muerto = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = goomba.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(4 * velocidad * (mirandoIzquierda ? -1 : 1), rb.velocity.y);
        if (muerto)
        {
            rb.velocity = rb.velocity * 0;
            Destroy(this.gameObject, 1f);
        }
    }

    public void cambiarDireccion()
    {
        mirandoIzquierda = !mirandoIzquierda;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool colisionaSaltoEnemigo = false;

        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y == -1f)
                {
                    animator.SetBool("Muerte", true);
                    muerto = true;
                }
            }
        }
    }
}

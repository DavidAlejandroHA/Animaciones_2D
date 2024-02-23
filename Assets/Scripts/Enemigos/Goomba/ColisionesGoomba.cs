using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesGoomba : MonoBehaviour
{
    public GameObject goomba;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("a");
        if (collision.gameObject.CompareTag("Suelo"))
        {
            //Debug.Log("b");
            goomba.gameObject.GetComponent<GoombaMovimiento>().cambiarDireccion();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable para la velocidad de desplazamiento
    [SerializeField]
    private float speed;

    // Variable para la velocidad de salto
    [SerializeField]
    private float jumpSpeed;

    // Rigidbody del jugador
    private Rigidbody2D rb;

    // Animator del jugador
    private Animator animador;

    // SpriteRenderer del jugador
    private SpriteRenderer sprender;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animador = gameObject.GetComponent<Animator>();
        sprender = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)) 
        {
            rb.AddForce(Vector3.left * speed);
            //rb.velocity += Vector2.left * speed;
            animador.SetBool("caminando",true);

        } else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
            animador.SetBool("caminando",true);

        } else if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            animador.SetTrigger("saltando");

        }else {
            animador.SetBool("caminando",false);
            
        }
    }
}

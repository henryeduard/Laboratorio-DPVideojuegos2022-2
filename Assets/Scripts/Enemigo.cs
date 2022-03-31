using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    // Vida del enemigo
    [SerializeField]
    private int vida;

    // Velocidad del enemigo
    [SerializeField]
    private float velocidad;

    // Rigidbody del enemigo
    private Rigidbody2D rb;

    // Animator del enemigo
    private Animator animador;

    // SpriteRenderer del enemigo
    private SpriteRenderer sprender;

    // Vector de la direccion de movimiento
    private Vector3 direccion;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animador = gameObject.GetComponent<Animator>();
        sprender = gameObject.GetComponent<SpriteRenderer>();

        direccion = Vector3.left;
        sprender.flipX = true;
    }

    // Movimiento del enemigo.
    // Cuando choca cambia de direccion.
    public void FixedUpdate()
    {
        rb.AddForce(direccion * velocidad);
    }

    // Si un enemigo choca contra una pared, cambia de direccion.
    private void OnCollisionEnter2D(Collision2D other) {
        direccion = -direccion;
        sprender.flipX = !(sprender.flipX);
    }

    // Baja la vida del enemigo y si la vida se acaba entonces lo destruye.
    public void BajarVida(int daño) {
        vida -= daño;
        animador.SetTrigger("recibirDano");

        if(vida <= 0){
            Destroy(gameObject);
        }
    }
    
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
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

    // Layer del suelo
    [SerializeField]
    private LayerMask capaSuelo;
    
    // Tamaño que tendra nuestro raycast
    [SerializeField]
    private float longitudRayo;

    // El controlador para disparar
    [SerializeField]
    private Transform disparador;


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

        // Raycast para detectar el suelo y piso
        //RaycastHit2D rayoSalto = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, (1 << capaSuelo) | (1 << capaPared));
        RaycastHit2D rayoSalto = Physics2D.Raycast(transform.position, Vector2.down, longitudRayo, capaSuelo);
        Debug.DrawRay(transform.position, Vector2.down * longitudRayo, Color.green);

        if (Input.GetKey(KeyCode.A)) 
        {
            rb.AddForce(Vector3.left * speed);
            //rb.velocity += Vector2.left * speed;
            animador.SetBool("caminando",true);
            sprender.flipX = true;
            disparador.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

        } else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
            animador.SetBool("caminando",true);
            sprender.flipX = false;
            disparador.eulerAngles = new Vector3(0, transform.eulerAngles.y + 360, 0);
            

        } else {
            animador.SetBool("caminando",false);
            
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && rayoSalto)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            animador.SetTrigger("saltando");
            
        }
    }
}

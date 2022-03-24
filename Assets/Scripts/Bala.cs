using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    // Velocidad de disparo de la bala
    [SerializeField]
    private float velocidadBala;

    // Tiempo de vida de la bala
    [SerializeField]
    private float tiempoVida;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidadBala * Time.deltaTime);
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Pared")){
            Destroy(gameObject);
        }
    }
}

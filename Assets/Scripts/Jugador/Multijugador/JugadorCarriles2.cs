using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorCarriles2 : MonoBehaviour
{
    [SerializeField] Rigidbody rb; // Cuerpo sometido a fisicas
    public float velocidad = 15f; // Que tan rapido avanza el Jugador

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 15f;
        Invoke("AumentarVelocidadInicial", 1f);

    }

    public void AumentarVelocidadInicial()
    {
        velocidad = 28f;
    }
    private void FixedUpdate()
    {

        //* Movimiento Adelante Infinito y Horizontal
        // Vector que mueve al GameObject hacia adelante con una velocidad (en un espacio 3D)
        Vector3 avanzar = transform.forward * velocidad * Time.fixedDeltaTime;

        // Mueve la posicion del GameObject la distancia de los 2 Vectores creados anteriormente (usando el RigidBody)
        rb.MovePosition(rb.position + avanzar);
    }
}

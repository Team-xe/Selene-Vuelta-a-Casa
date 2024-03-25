using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//* Script para que las Posiciones o Carriles puedan avanzar junto con el jugador
public class Carriles : MonoBehaviour
{
    [SerializeField] Rigidbody rb; // Cuerpo sometido a fisicas
    public float velocidad = 7.5f; // Que tan rapido avanza el Jugador

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){

        //* Movimiento Adelante Infinito y Horizontal
        // Vector que mueve al GameObject hacia adelante con una velocidad (en un espacio 3D)
        Vector3 avanzar = transform.forward * velocidad * Time.fixedDeltaTime;

        // Mueve la posicion del GameObject la distancia de los 2 Vectores creados anteriormente (usando el RigidBody)
        rb.MovePosition(rb.position + avanzar); 
    }
}

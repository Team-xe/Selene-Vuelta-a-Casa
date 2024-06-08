using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public JugadorMovimiento jugadorMovimiento;
    public AudioSource audioSource;
    private Jugador1 jugador1;
    private Jugador2 jugador2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>();
        jugador1 = GameObject.FindObjectOfType<Jugador1>();
        jugador2 = GameObject.FindObjectOfType<Jugador2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Jugador"){
            if(jugadorMovimiento.EsInvulnerable())
            {
                jugadorMovimiento.DestruirEnemigos();
            }
            else
            {
                jugadorMovimiento.Morir();
            }
        }
        if (other.gameObject.name == "Jugador1")
        {
            // Matar al jugador

            jugador1.Morir();
        }
        if (other.gameObject.name == "Jugador2")
        {
            // Matar al jugador

            jugador2.Morir();
        }
        Destroy(gameObject);
    }
}

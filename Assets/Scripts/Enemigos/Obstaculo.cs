using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public JugadorMovimiento jugadorMovimiento;
    private Jugador1 jugador1;
    private Jugador2 jugador2;

    void Start()
    {
        jugador1 = GameObject.FindObjectOfType<Jugador1>();
        jugador2 = GameObject.FindObjectOfType<Jugador2>();
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>(); // busca el Script del jugador para invocar el Morir()
    }

    /**
    ** Metodo para matar al Jugador al colisionar
    **/
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Jugador"){
            
            if (jugadorMovimiento.EsInvulnerable())
            {
                jugadorMovimiento.DestruirEnemigos();
            }
            else
            {
                jugadorMovimiento.Morir();
                AudioManager.instance.ReproducirEfectos("Caja");
            }
        }
        if (collision.gameObject.CompareTag("Jugador1"))
        {
            // Matar al jugador
            AudioManager.instance.ReproducirEfectos("Caja");
            jugador1.Morir();
        }
        if (collision.gameObject.CompareTag("Jugador2"))
        {
            // Matar al jugador
            AudioManager.instance.ReproducirEfectos("Caja");
            jugador2.Morir();
        }
    }
}

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
        if (gameObject.name == "Caja(Clone)" || gameObject.name == "Seta(Clone)"){
            Vector3 nuevaPos = transform.position;
            nuevaPos.y = 1f;
            transform.position = nuevaPos;
        }
        if (gameObject.name == "TroncoVertical(Clone)"){
            Vector3 nuevaPos = transform.position;
            nuevaPos.y = 2f;
            transform.position = nuevaPos;
        }
        if (gameObject.name == "Pajaro(Clone)"){
            Vector3 nuevaPos = transform.position;
            nuevaPos.y = 3.5f;
            transform.position = nuevaPos;
        }
        if (gameObject.name == "Caja(Clone)" || gameObject.name == "Seta(Clone)"){
            Vector3 nuevaPos = transform.position;
            nuevaPos.y = 1f;
            transform.position = nuevaPos;
        }

        

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
                Destroy(gameObject);
            }

            else
            {
                jugadorMovimiento.Morir();
                AudioManager.instance.ReproducirEfectos("Caja");
            }
        }
        if (collision.gameObject.name == "Escudo")
        {
            jugadorMovimiento.DestruirEnemigos();
            Destroy(gameObject);
        }


        if (collision.gameObject.CompareTag("Jugador1"))
        {
            // Matar al jugador
            Debug.Log("Jugador muerto: " + collision.gameObject.name);
            AudioManager.instance.ReproducirEfectos("Caja");
            jugador1.Morir();
        }
        if (collision.gameObject.CompareTag("Jugador2"))
        {
            // Matar al jugador
            Debug.Log("Jugador muerto: " + collision.gameObject.name);
            AudioManager.instance.ReproducirEfectos("Caja");
            jugador2.Morir();
        }
    }
}

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

        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Jugador"){
            if(jugadorMovimiento.EsInvulnerable())
            {
                print("Destruir Enemigos ! (Poder azul)");
                jugadorMovimiento.DestruirEnemigos();
            }
            else
            {
                print("Morir por colisionar, bruh");
                jugadorMovimiento.Morir();
                AudioManager.instance.ReproducirEfectos("Caja");
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

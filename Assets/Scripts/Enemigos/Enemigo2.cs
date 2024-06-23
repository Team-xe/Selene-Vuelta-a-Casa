using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public float tiempomin = 1f; 
    private float tiempomax = 5f;
    private float tiempoSalto;
    private JugadorMovimiento jugadorMovimiento;
    private Rigidbody rb;
    public AudioSource audioSource;
    private Jugador1 jugador1;
    private Jugador2 jugador2;

    // Start is called before the first frame update
    void Start()
    {
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>();
        rb = GetComponent<Rigidbody>();
        jugador1 = GameObject.FindObjectOfType<Jugador1>();
        jugador2 = GameObject.FindObjectOfType<Jugador2>();
        calcularTiempo();
    }
    
    public void Salto()
    {
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Jugador"){
            if (jugadorMovimiento.EsInvulnerable())
            {
                jugadorMovimiento.DestruirEnemigos();
            }
            else
            {
                jugadorMovimiento.Morir();
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
            
            jugador1.Morir();
        }
        if (collision.gameObject.CompareTag("Jugador2"))
        {
            // Matar al jugador
            
            jugador2.Morir();
        }
    }

    private void calcularTiempo()
    {
        tiempoSalto = Time.time + Random.Range(tiempomin, tiempomax);
    }


    // Update is called once per frame
    void Update()
    {
    
        if (Time.time >= tiempoSalto)
        {
            Salto();
            calcularTiempo();
            audioSource.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ZORRO
/// </summary>
public class Enemigo1 : MonoBehaviour
{
    public float tiemposaltar = 3f;
    private float tiempo = 0f;
    private JugadorMovimiento jugadorMovimiento;
    private Rigidbody rb;
    public AudioSource audioSource;
    private Jugador1 jugador1;
    private Jugador2 jugador2;

    private Vector3[] carrilesPos = new Vector3[3] { new Vector3(-3.5f, 0, 0), new Vector3(0, 0, 0), new Vector3(3.5f, 0, 0) }; // Positions on the x-axis
    private Vector3 targetCarril; 
    private int carrilIndexActual; 
    public float velocidadPatrulla = 5f;

    void Start()
    {
        audioSource.Play();
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>();
        jugador1 = GameObject.FindObjectOfType<Jugador1>();
        jugador2 = GameObject.FindObjectOfType<Jugador2>();
        rb = GetComponent<Rigidbody>();

        // Set the initial lane
        carrilIndexActual = Random.Range(0, carrilesPos.Length);
        targetCarril = carrilesPos[carrilIndexActual];
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= tiemposaltar)
        {
            Salto();
            tiempo = 0f;
        }

        Patrullar();
        Bordes();
    }

    private void Patrullar()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetCarril.x, transform.position.y, transform.position.z), velocidadPatrulla * Time.deltaTime);
        if (Vector3.Distance(transform.position, new Vector3(targetCarril.x, transform.position.y, transform.position.z)) < 0.1f)
        {
            int nuevoCarrilIndex;
            do
            {
                nuevoCarrilIndex = Random.Range(0, carrilesPos.Length);
            } while (nuevoCarrilIndex == carrilIndexActual);

            carrilIndexActual = nuevoCarrilIndex;
            targetCarril = carrilesPos[carrilIndexActual];
        }
    }

    public void Salto()
    {
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }

    private void Bordes()
    {
        if (transform.position.x > 3.4f)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position = new Vector3(3.4f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -3.4f)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.position = new Vector3(-3.4f, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            if (jugadorMovimiento.EsInvulnerable())
            {
                print("Destruir Enemigos ! (Poder azul)");
                jugadorMovimiento.DestruirEnemigos();
            }
            else
            {
                print("Morir por colisionar, bruh");
                AudioManager.instance.ReproducirEfectos("Zorro");
                jugadorMovimiento.Morir();
            }
            
            
        }
        if (collision.gameObject.CompareTag("Jugador1"))
        {
            // Matar al jugador
            
            AudioManager.instance.ReproducirEfectos("Zorro");
            jugador1.Morir();
        }
        if (collision.gameObject.CompareTag("Jugador2"))
        {
            // Matar al jugador
            AudioManager.instance.ReproducirEfectos("Zorro");
            jugador2.Morir();
        }
    }
}

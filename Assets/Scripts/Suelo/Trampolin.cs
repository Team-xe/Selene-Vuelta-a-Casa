using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float fuerzaImpulso = 2;

    public JugadorMovimiento jugadorMovimiento;

    private Jugador1 jugador1;
    private Jugador2 jugador2;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jugador")
        {
            AplicarImpulsoJugador();
        }

        if (other.gameObject.name == "Jugador1")
        {
            AplicarImpulsoJugador1();
        }

        if (other.gameObject.name == "Jugador2")
        {
            AplicarImpulsoJugador2();
        }
    }

    public void AplicarImpulsoJugador()
    {
        jugadorMovimiento = FindObjectOfType<JugadorMovimiento>();
        jugadorMovimiento.trampolinSalto();
    }

    public void AplicarImpulsoJugador1()
    {
        jugador1 = GameObject.FindObjectOfType<Jugador1>();
        jugador1.trampolinSalto();
    }

    public void AplicarImpulsoJugador2()
    {
        jugador2 = GameObject.FindObjectOfType<Jugador2>();
        jugador2.trampolinSalto();
    }
}

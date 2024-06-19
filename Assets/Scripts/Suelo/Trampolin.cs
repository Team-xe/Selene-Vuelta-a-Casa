using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float fuerzaImpulso = 25;

    public JugadorMovimiento jugadorMovimiento;

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
    }

    public void AplicarImpulsoJugador()
    {
        jugadorMovimiento = FindObjectOfType<JugadorMovimiento>();
        jugadorMovimiento.trampolinSalto();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder2 : MonoBehaviour
{
    public static bool invulnerable;

    public JugadorMovimiento jugadorMovimiento;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jugador")
        {
            
            HacerInvulnerableJugador();
        }
    }

    public void HacerInvulnerableJugador(){
        jugadorMovimiento = FindObjectOfType<JugadorMovimiento>();
        jugadorMovimiento.ActivarInvulnerabilidad();
        Destroy(gameObject);
    }
}


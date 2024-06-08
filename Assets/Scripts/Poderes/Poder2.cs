using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder2 : MonoBehaviour
{
    public static bool invulnerable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jugador")
        {
            JugadorMovimiento jugadorMovimiento = other.GetComponent<JugadorMovimiento>();
            if (jugadorMovimiento != null)
            {
                jugadorMovimiento.ActivarInvulnerabilidad();
            }
            Destroy(gameObject);
        }
    }
}


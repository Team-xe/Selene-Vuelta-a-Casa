using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PODER AZUL
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

        if (other.gameObject.CompareTag("Enemigo")){
            Destroy(other.gameObject);
        }
    }

    public void HacerInvulnerableJugador(){
        jugadorMovimiento = FindObjectOfType<JugadorMovimiento>();
        jugadorMovimiento.ActivarInvulnerabilidad();
        Destroy(gameObject);
    }
}


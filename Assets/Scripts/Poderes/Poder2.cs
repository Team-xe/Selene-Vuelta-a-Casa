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
            invulnerable = true;
            Destroy(gameObject);

            Invoke("DesactivarInvulnerable", 10f);
        }
    }

    private void DesactivarInvulnerable()
    {
        invulnerable = false;
    }
}


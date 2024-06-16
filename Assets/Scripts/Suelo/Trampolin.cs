using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float fuerzaImpulso = 65f;

    public JugadorMovimiento jugadorMovimiento;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Método que se llama cuando otro collider entra en el trigger
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
        if (jugadorMovimiento != null && jugadorMovimiento.rb != null)
        {
            jugadorMovimiento.rb.AddForce(Vector3.up * fuerzaImpulso, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}

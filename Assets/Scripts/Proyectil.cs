using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public JugadorMovimiento jugadorMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>(); // busca el Script del jugador para invocar el Morir()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Jugador"){
            // Matar al jugador
            jugadorMovimiento.Morir();
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    JugadorMovimiento jugadorMovimiento;

    void Start()
    {
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>(); // busca el Script del jugador para invocar el Morir()
    }

    /**
    ** Metodo para matar al Jugador al colisionar
    **/
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Jugador"){
            // Matar al jugador
            jugadorMovimiento.Morir();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

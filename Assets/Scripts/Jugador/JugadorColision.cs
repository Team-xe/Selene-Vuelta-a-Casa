using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorColision : MonoBehaviour
{
    public ContadorMonedas puntaje;


    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Moneda")) {
            puntaje.Sumar(1);
        }

        if (other.gameObject.CompareTag("Diamante")){
            puntaje.Sumar(10);
        }
    }
}

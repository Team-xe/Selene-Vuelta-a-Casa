using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorColision : MonoBehaviour
{
    public ContadorMonedas contadorMonedas;
    public GameObject particulasPoder1;
    public GameObject particulasPoder2;

    public bool poder2 = false;
    public GameObject fuegoFatuo;
    public GuardadoManager guardadoManager;
    

    void Start()
    {
        // Buscar el GuardadoManager en la escena
        //guardadoManager = FindObjectOfType<GuardadoManager>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Moneda")) {
            contadorMonedas.Sumar(1);
        }

        if (other.gameObject.CompareTag("Poder1")) {
            particulasPoder1.SetActive(true);
            Invoke("ParticulasPoder1",3);
        }

        if (other.gameObject.CompareTag("Poder2")){
            poder2 = true;
            Invoke("Poder2Desactivar",10);
        }

        if (other.gameObject.CompareTag("Enemigo") && poder2 == true) {
            particulasPoder2.SetActive(true);
            Invoke("ParticulasPoder2",3);
        }
        /*if (other.gameObject.CompareTag("Diamante")){
            puntaje.Sumar(10);
        }
        */
    }

    private void Poder2Desactivar(){
        poder2 = false;
    }

    private void ParticulasPoder1(){
        particulasPoder1.SetActive(false);
    }
    private void ParticulasPoder2(){
        particulasPoder2.SetActive(false);
    }
}

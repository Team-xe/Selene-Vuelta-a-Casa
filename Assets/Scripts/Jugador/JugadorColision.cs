using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorColision : MonoBehaviour
{
    public ContadorMonedas contadorMonedas;
    public GameObject particulasPoder1;
    public GuardadoManager guardadoManager;
    

    void Start()
    {
        // Buscar el GuardadoManager en la escena
        //guardadoManager = FindObjectOfType<GuardadoManager>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Moneda")) {
            contadorMonedas.Sumar(1);
            AudioManager.instance.ReproducirEfectos("Moneda");
        }

        if (other.gameObject.CompareTag("MonedaEspecial")) {
            contadorMonedas.Sumar(5);
            AudioManager.instance.ReproducirEfectos("Moneda");
        }

        if (other.gameObject.CompareTag("Poder1")) {
            particulasPoder1.SetActive(true);
            Invoke("ParticulasPoder1",3);
        }

        /*if (other.gameObject.CompareTag("Diamante")){
            puntaje.Sumar(10);
        }
        */

        if (other.gameObject.CompareTag("SueloCascada"))
        {
            AudioManager.instance.ReproducirEfectos("Cascada");
        }

        
    }

    private void ParticulasPoder1(){
        particulasPoder1.SetActive(false);
    }
    
}

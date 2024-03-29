using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
   //int contador = 0;
   public Rigidbody rb;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Jugador")) {
            //contador++;
            Debug.Log("Moneda+1");
            rb.AddForce(Vector3.up * 30f, ForceMode.Impulse);
            Destroy(gameObject,0.2f);
        }
    }

    //TODO: Sonido al recoger

    //TODO: Contador +1 monedas
}

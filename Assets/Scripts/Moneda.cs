using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moneda : MonoBehaviour
{
   //int contador = 0;
   public Rigidbody rb;

     void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Jugador")) {
            Debug.Log("Moneda+1");
            
            rb.AddForce(Vector3.up * 30f, ForceMode.Impulse);
            Destroy(gameObject,0.2f);
        }
    }

    void Update(){
        transform.Rotate(Vector3.right, 50f * Time.deltaTime);
    }

    //TODO: Sonido al recoger
}

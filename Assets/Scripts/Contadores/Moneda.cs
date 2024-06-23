using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moneda : MonoBehaviour
{
   public Rigidbody rb;

    public AudioSource audioSource;

    private static float tiempoUltimaMoneda;
    private static float pitchOriginal;
    private static float incrementoPitch = 0.1f; // Incremento del pitch
    private static float tiempoMaximoSinRecoger = 0.4f;

    void Start(){
        Destroy(gameObject,40f);

        if (audioSource != null)
        {
            pitchOriginal = audioSource.pitch;
        }

    }
     void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Jugador")) { 
                       
            rb.AddForce(Vector3.up * 30f, ForceMode.Impulse);
            if (Time.time - tiempoUltimaMoneda <= tiempoMaximoSinRecoger)
            {
                audioSource.pitch += incrementoPitch;
            }
            else
            {
                audioSource.pitch = pitchOriginal;
            }

            audioSource.Play();

            tiempoUltimaMoneda = Time.time; ;
            Destroy(gameObject,0.2f);
        }
    }

    void Update(){
        transform.Rotate(Vector3.right, 50f * Time.deltaTime);
    }
}

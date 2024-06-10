using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder1 : MonoBehaviour
{
    
    public void ElevarEnemigos(){
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject enemigo in enemigos)
        {
            Rigidbody enemigoRb = enemigo.GetComponent<Rigidbody>();
            enemigoRb.AddForce(Vector3.up * 200f, ForceMode.Impulse);
            enemigoRb.constraints &= ~RigidbodyConstraints.FreezePositionY;
            enemigoRb.useGravity = false; // Desactivar la gravedad
            Destroy(enemigo,4);
        }

        Destroy(gameObject);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jugador")
        {
            ElevarEnemigos();
        }
        
    }
}

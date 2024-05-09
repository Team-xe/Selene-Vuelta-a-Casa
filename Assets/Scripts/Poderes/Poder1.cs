using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poder1 : MonoBehaviour
{
    
    
    public void Explotar(GameObject enemigo)
    {
        Rigidbody enemigoRb = enemigo.GetComponent<Rigidbody>();
        enemigoRb.AddForce(Vector3.up * 200f, ForceMode.Impulse);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jugador")
        {
            Destroy(gameObject);
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

            foreach (GameObject enemigo in enemigos)
            {
                Explotar(enemigo);
                Destroy(enemigo,4);
            }
        }
        
    }
}

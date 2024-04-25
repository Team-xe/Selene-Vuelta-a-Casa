using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{

    public GameObject proyectilPrefab;

    public float distanciaLanzamiento = -2.2f;
    public float fuerzaLanzamiento = -5f;
    public float intervaloLanzamiento = 5f;
    private float tiempo = 0f;

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= intervaloLanzamiento){
            Disparar();
            tiempo = 0f;
        }
    }

    void Disparar(){
        Vector3 posicionInicial = transform.position + Vector3.forward * distanciaLanzamiento;

        GameObject proyectil = Instantiate(proyectilPrefab,posicionInicial,Quaternion.identity);

        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,0f,fuerzaLanzamiento);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    SuelosGenerador sueloGenerador; // Variable para guardar el Script que genera Suelos
    

    void Start()
    {
        sueloGenerador = GameObject.FindObjectOfType<SuelosGenerador>(); // Guarda el Script SuelosGenerador (buscandolo)
        GenerarObstaculo(); // Suelo nace con 1 Obstaculo
    }

    /**
    ** Metodo que Genera 1 Suelo y Destruye este Suelo actual de este Script al salir de la Colision con algo 
    **/
    private void OnTriggerExit(Collider other){
        sueloGenerador.GenerarSuelo(); // Accede al Script SuelosGenerador y Genera otro Suelo en alguna posicion
        Destroy(gameObject,2); // Destruye 1 Suelo despues de 2 segundos
    }


    // Obstaculos
    public GameObject obstaculo1Prefab;
    public GameObject obstaculo2Prefab;
    public GameObject obstaculo3Prefab;
    

    /**
    ** Metodo para generar 1 o mas Obstaculos en un punto random entre los 3 gameobjects que marcan posiciones izq, medio, der de un Suelo
    **/
    void GenerarObstaculo(){

        //* Escoger un punto random (1,2,3) para generar el obstaculo

        int obstaculoGenIndex = Random.Range(2,5); // numero random
        // Guarda la posicion 1, 2 o 3 en "puntoGen"
        Transform puntoGen = transform.GetChild(obstaculoGenIndex).transform; // regresa el componente transform de uno de los 3 GameObjects obstaculoGen izq, medio, der
        

        //* Generar 1 de los 3 obstaculos en la posicion "puntoGen"

        float probabilidad = Random.Range (0f,1f); // probabilidad de uno u otro
    
        // Obstaculo 1
        if (probabilidad < 0.7f){
            Instantiate(obstaculo1Prefab,puntoGen.position,Quaternion.identity,transform);
        }

        // Obstaculo 3
        if (probabilidad < 0.1f){
            Transform puntoAire = puntoGen;
            puntoAire.position = new Vector3(puntoGen.position.x,puntoGen.position.y + 2f,puntoGen.position.z);
            Instantiate(obstaculo3Prefab,puntoAire.position,Quaternion.identity,transform);
        }
        // Obstaculo 2
        if (probabilidad > 0.7){
            Instantiate(obstaculo2Prefab,puntoGen.position,Quaternion.identity,transform);
        }
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
** Script para Generar Suelos y mantener 15 suelos permanentementes en Juego
**/
public class SuelosGenerador : MonoBehaviour
{
    public GameObject suelo;
    public Vector3 puntoGeneracion;


    /**
    ** Metodo que Genera 1 Suelo instanciandolo en el Punto del Suelo Anterior (tomado por el Suelo que ya esta creado)
    **/
    public void GenerarSuelo(){


        // Creo 1 Suelo en el puntoGeneracion que tiene el Suelo Anterior
        GameObject temp = Instantiate(suelo,puntoGeneracion,Quaternion.identity); 

        // Obtengo la posicion del GameObject "PuntoGenProximo" que esta dentro del Suelo (2do gameObject hijo dentro de Prefab Suelo)
        puntoGeneracion = temp.transform.GetChild(1).transform.position;
        // Asi se va actualizando el punto donde se genera el nuevo Suelo en la posicion "puntoGeneracion" de cada ultimo Suelo creado
    }


    void Start()
    {
        for (int i = 0; i < 15; i++){
            GenerarSuelo(); // Genero 15 suelos de mapa permanentes (se destruye 1 y se genera 1 en el metodo)
        }
    }
}

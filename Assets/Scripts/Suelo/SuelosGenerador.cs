using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
** Script para Generar Suelos y mantener 15 suelos permanentementes en Juego
**/
public class SuelosGenerador : MonoBehaviour
{
    //public GameObject suelo;
    public GameObject[] suelos;
    //public GameObject sueloNormal;  // 1
    //public GameObject sueloAgujero; // 2
    //public GameObject sueloAgua;    // 3
    public Vector3 puntoGeneracion;

    public int tipo = 1;
    public int repeticiones = 0;
    public float random;

    public float tiempoTiposSuelos = 0f;


    void Update()
    {
        if (tiempoTiposSuelos <= 6f){
            tiempoTiposSuelos += Time.deltaTime;
        }
    }

    /**
    ** Metodo que Genera 1 Suelo instanciandolo en el Punto del Suelo Anterior (tomado por el Suelo que ya esta creado)
    **/

    public void GenerarSuelo(){

        // Creo 1 Suelo en el puntoGeneracion que tiene el Suelo Anterior
        GameObject temp = Instantiate(suelos[tipo-1],puntoGeneracion,Quaternion.identity); 

        // Obtengo la posicion del GameObject "PuntoGenProximo" que esta dentro del Suelo (2do gameObject hijo dentro de Prefab Suelo)
        puntoGeneracion = temp.transform.GetChild(1).transform.position;
        // Asi se va actualizando el punto donde se genera el nuevo Suelo en la posicion "puntoGeneracion" de cada ultimo Suelo creado
        if (tiempoTiposSuelos > 6f){
            // Suelo Normal
            if (tipo == 1){
                repeticiones++;
                if (repeticiones == 10){
                    CambiarTipoSuelo();
                    return;
                }
            }
            
            // Suelo Agua
            else if (tipo == 3){
                repeticiones++;
                if (repeticiones == 1){
                    CambiarTipoSuelo();
                    return;
                }
            }

            // Suelo Agujero
            else if (tipo == 2){
                CambiarTipoSuelo();
                return;
            }
        }
    }

    public void CambiarTipoSuelo(){

        // Genera un número aleatorio entre 1 y 4 (ambos incluidos)
        float random = Random.Range(1, 4); // El límite superior es exclusivo, por eso se usa 4 para incluir 3.
        while (random == tipo){
            random = Random.Range(1, 4); // El límite superior es exclusivo, por eso se usa 4 para incluir 3.
        }
        // Convierte el número flotante generado en un entero
        tipo = Mathf.RoundToInt(random);
        repeticiones = 0;
    }

    void Start()
    {
        for (int i = 0; i < 15; i++){
            GenerarSuelo(); // Genero 15 suelos de mapa permanentes (se destruye 1 y se genera 1 en el metodo)
        }
    }
}

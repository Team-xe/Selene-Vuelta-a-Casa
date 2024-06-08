using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloRecicladoMultijugador : MonoBehaviour
{
    public int poolCantidad = 18; // Cantidad total de plataformas

    public int sueloActual = 0; // Índice del suelo actual

    public GameObject[] suelos; // Array que contiene todas las plataformas

    

    void Start()
    {
        for (int i = 0; i < poolCantidad; i++)
        {
            // Inicialización si es necesario
        }
    }

    

    public void MoverSuelo()
    {
        // Obtener la posición Z del suelo actual
        float zActual = suelos[sueloActual].transform.position.z;

        // Índice del suelo más adelante en el eje Z
        int sueloMasAdelante = sueloActual;
        float zMasAdelante = zActual;

        for (int i = 0; i < poolCantidad; i++)
        {
            // Obtener la posición Z del suelo en la posición 'i'
            float zSuelo = suelos[i].transform.position.z;

            // Comparar las posiciones Z
            if (zSuelo > zMasAdelante)
            {
                sueloMasAdelante = i;
                zMasAdelante = zSuelo;
            }
        }

        // Obtener la posición de PuntoGenProximo del suelo más adelante
        Transform puntoGenProximo = suelos[sueloMasAdelante].transform.Find("PuntoGenProximo");
        Vector3 puntoGenProximoFix = puntoGenProximo.position;
        puntoGenProximoFix.y = 0f;
        puntoGenProximo.position = puntoGenProximoFix;

        // Comprobar si se ha encontrado PuntoGenProximo
        if (puntoGenProximo != null)
        {
            // Mover el suelo actual a la posición de PuntoGenProximo del suelo más adelante
            suelos[sueloActual].transform.position = puntoGenProximo.position;

            Debug.Log("Moviendo " + suelos[sueloActual].name + " a la posición de " + suelos[sueloMasAdelante].name);
        }
        else
        {
            Debug.LogError("No se encontró 'PuntoGenProximo' en el suelo: " + suelos[sueloMasAdelante].name);
        }

        // Actualizar el índice del suelo actual
        sueloActual = (sueloActual + 1) % poolCantidad;
    }

   
}

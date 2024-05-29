using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadoManager : MonoBehaviour
{
    private const string TotalMonedaKey = "TotalMonedaKey";

    private const string TotalPuntajeKey = "TotalPuntaje";

    private int totalMoneda = 0;
    private int totalPuntaje = 0;

    void Start()
    {
        // Cargar el total de monedas desde PlayerPrefs
        totalMoneda = PlayerPrefs.GetInt(TotalMonedaKey, 0); // El 0 devuelve el valor que tiene guardado TotalMonedaKey

        // Cargar el total de puntaje desde PlayerPrefs
        totalPuntaje = PlayerPrefs.GetInt(TotalPuntajeKey, 0);

        print("total monedas cargado: " + totalMoneda);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            ReiniciarMonedas();
        }
    }

    //* Agregar Monedas al Total Monedas en PlayerPrefs
    public void agregarMoneda(int monedasAgregar)
    {
        print("! Se añade 1 moneda");

        totalMoneda += monedasAgregar;

        // Guardar el total de monedas actualizado en PlayerPrefs
        PlayerPrefs.SetInt(TotalMonedaKey, totalMoneda);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }

    //* Agregar Puntaje al Total Puntaje en PlayerPrefs
    public void aniadirPuntaje(int puntosAgregar)
    {
        totalPuntaje += puntosAgregar;
        // Guardar el total de monedas actualizado en PlayerPrefs

        PlayerPrefs.SetInt(TotalPuntajeKey, totalPuntaje);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }


    //* Recuperar el total de monedas
    public int GetTotalCoins()
    {
        print("! Se obtiene Get Total Coins");
        return totalMoneda;
    }

    public int GetTotalpoints()
    {
        return totalPuntaje;
    }


    // Reiniciar el total de monedas (test unity)
    public void ReiniciarMonedas()
    {
        totalMoneda = 0;
        PlayerPrefs.SetInt(TotalMonedaKey, totalMoneda);
        PlayerPrefs.Save(); // Guardar los cambios
    }
}


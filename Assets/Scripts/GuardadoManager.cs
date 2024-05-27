using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadoManager : MonoBehaviour
{
    private const string MonedaKey = "TotalCoins";

    private const string PuntajeKey = "TotalPuntaje";
    private int totalMoneda = 0;
    private int totalPuntaje = 0;

    void Start()
    {
        // Cargar el total de monedas desde PlayerPrefs
        totalMoneda = PlayerPrefs.GetInt(MonedaKey, 0);

        // Cargar el total de puntaje desde PlayerPrefs
        totalPuntaje = PlayerPrefs.GetInt(PuntajeKey, 0);

        print("total cargado: " + totalMoneda);
    }

    // Llama a esta función cuando quieras añadir monedas
    public void aniadirMoneda(int coinsToAdd)
    {
        print("se añade 1 moneda");
        totalMoneda += coinsToAdd;
        // Guardar el total de monedas actualizado en PlayerPrefs
        PlayerPrefs.SetInt(MonedaKey, totalMoneda);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }

    public void aniadirPuntaje(int pointToAdd)
    {
        totalPuntaje += pointToAdd;
        // Guardar el total de monedas actualizado en PlayerPrefs
        PlayerPrefs.SetInt(PuntajeKey, totalPuntaje);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }


    // Función para recuperar el total de monedas
    public int GetTotalCoins()
    {
        return totalMoneda;
    }

    public int GetTotalpoints()
    {
        return totalPuntaje;
    }

/*
    // Opcionalmente, puedes querer reiniciar el total de monedas (para propósitos de prueba)
    public void ResetTotalCoins()
    {
        totalCoins = 0;
        PlayerPrefs.SetInt(CoinKey, totalCoins);
        PlayerPrefs.Save(); // Guardar los cambios
    }
*/
}


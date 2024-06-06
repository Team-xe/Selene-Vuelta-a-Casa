using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadoManager : MonoBehaviour
{

    //* GUARDADO DE VARIABLES DE CANTIDADES Y MONEDAS
    private const string TotalMonedaKey = "TotalMonedaKey";
    private const string TotalPuntajeKey = "TotalPuntaje";
    private const string TotalComidaKey = "TotalComidaKey";

    private const string TotalPescadoKey = "TotalPescadoKey";
    private const string TotalSushiKey = "TotalSushiKey";
    private const string TotalHamburguesaKey = "TotalHamburguesaKey";


    //* GUARDADO DE VARIABLES DE ASPECTO JUGADOR
    private const string ModeloCapaRoja = "ModeloCapaRoja";
    private const string ModeloCapaCeleste = "ModeloCapaCeleste";
    private const string ModeloCapaVerde = "ModeloCapaVerde";
    private const string ModeloCapaMago = "ModeloCapaMago";
    private const string ModeloPielBlanca = "ModeloPielBlanca";
    private const string ModeloPielNaranja = "ModeloPielNaranja";
    private const string ModeloPielNegra = "ModeloPielNegra";
    
    private const string CapaActual = "CapaActual";

    private int capaActual = 0;

    private int modeloCapaRoja = 1;
    private int modeloCapaCeleste = 0;
    private int modeloCapaVerde = 0;
    private int modeloCapaMago = 0;
    private int modeloPielBlanca = 1;
    private int modeloPielNaranja = 0;
    private int modeloPielNegra = 0;

    private int totalMoneda = 0;
    private int totalPuntaje = 0;
    private int totalComida = 0;


    private int totalPescado = 0;
    private int totalSushi = 0;
    private int totalHamburguesa = 0;

    void Start()
    {
        // Cargar el total desde PlayerPrefs
        totalMoneda = PlayerPrefs.GetInt(TotalMonedaKey, 0); // El 0 devuelve el valor que tiene guardado TotalMonedaKey
        totalPuntaje = PlayerPrefs.GetInt(TotalPuntajeKey, 0);
        totalPescado = PlayerPrefs.GetInt(TotalPescadoKey, 0);

        totalSushi = PlayerPrefs.GetInt(TotalSushiKey, 0);
        totalPescado = PlayerPrefs.GetInt(TotalPescadoKey, 0);
        totalHamburguesa = PlayerPrefs.GetInt(TotalHamburguesaKey, 0);

        modeloCapaRoja = PlayerPrefs.GetInt(ModeloCapaRoja, 0);
        modeloCapaCeleste = PlayerPrefs.GetInt(ModeloCapaCeleste, 0);
        modeloCapaVerde = PlayerPrefs.GetInt(ModeloCapaVerde, 0);
        modeloCapaMago = PlayerPrefs.GetInt(ModeloCapaMago, 0);

        modeloPielBlanca = PlayerPrefs.GetInt(ModeloPielBlanca, 0);

        print("--- PLAYER PREFS ---");
        print("monedas: "+totalMoneda.ToString()+", pescado: "+totalPescado.ToString()+", sushi: "+totalSushi.ToString()+", hamburg: "+totalHamburguesa.ToString());
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            ReiniciarDatos();
        }
    }

    //* Agregar Monedas al Total Monedas en PlayerPrefs
    public void agregarMoneda(int monedasAgregar)
    {
        totalMoneda += monedasAgregar;
        // Guardar el total de monedas actualizado en PlayerPrefs
        PlayerPrefs.SetInt(TotalMonedaKey, totalMoneda);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }

    //* Agregar Comida al Total Comida en PlayerPrefs
    public void agregarComida(int cantidadAgregar)
    {
        totalComida += cantidadAgregar;
        // Guardar el total de pescados actualizado en PlayerPrefs
        PlayerPrefs.SetInt(TotalComidaKey, totalComida);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }



    //* Agregar Pescados al Total Pescados en PlayerPrefs
    public void agregarPescado(int cantidadAgregar)
    {
        totalPescado += cantidadAgregar;
        // Guardar el total de pescados actualizado en PlayerPrefs
        PlayerPrefs.SetInt(TotalPescadoKey, totalPescado);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }

    //* Agregar Sushi al Total Sushis en PlayerPrefs
    public void agregarSushi(int cantidadAgregar)
    {
        totalSushi += cantidadAgregar;
        // Guardar el total de pescados actualizado en PlayerPrefs
        PlayerPrefs.SetInt(TotalSushiKey, totalSushi);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }

    //* Agregar Sushi al Total Sushis en PlayerPrefs
    public void agregarHamburguesa(int cantidadAgregar)
    {
        totalHamburguesa += cantidadAgregar;
        // Guardar el total de pescados actualizado en PlayerPrefs
        PlayerPrefs.SetInt(TotalHamburguesaKey, totalHamburguesa);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }

    



    //! Borrar probablemente
    /*
    //* Agregar Puntaje al Total Puntaje en PlayerPrefs
    public void aniadirPuntaje(int puntosAgregar)
    {
        totalPuntaje += puntosAgregar;
        // Guardar el total de monedas actualizado en PlayerPrefs

        PlayerPrefs.SetInt(TotalPuntajeKey, totalPuntaje);
        PlayerPrefs.Save(); // Asegurarse de guardar los cambios
    }
    */

    // Reiniciar el total de monedas (test unity)
    public void ReiniciarDatos()
    {
        totalMoneda = 0;
        totalComida = 0;

        totalPescado = 0;
        totalSushi = 0;
        totalHamburguesa = 0;
        
        PlayerPrefs.SetInt(TotalMonedaKey, totalMoneda);
        PlayerPrefs.SetInt(TotalComidaKey, totalComida);

        PlayerPrefs.SetInt(TotalPescadoKey, totalPescado);
        PlayerPrefs.SetInt(TotalSushiKey, totalPescado);
        PlayerPrefs.SetInt(TotalHamburguesaKey, totalPescado);
        PlayerPrefs.Save(); // Guardar los cambios

        print("--- REINICIO DATOS PLAYER PREFS ---");
        print("monedas: "+totalMoneda.ToString()+", pescado: "+totalPescado.ToString()+", sushi: "+totalSushi.ToString()+", hamburg: "+totalHamburguesa.ToString());
    }
}


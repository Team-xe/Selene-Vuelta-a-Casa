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

    private const string CapaVerdeComprada = "CapaVerdeComprada";
    private const string CapaCelesteComprada = "CapaCelesteComprada";
    private const string CapaMagoComprada = "CapaMagoComprada";
    private const string PielNaranjaComprada = "PielNaranjaComprada";
    private const string PielNegraComprada = "PielNegraComprada";

    private int capaActual = 0;

    private int modeloPielBlanca = 1;
    private int modeloPielNaranja = 0;
    private int modeloPielNegra = 0;

    private int modeloCapaRoja = 1;
    private int modeloCapaCeleste = 0;
    private int modeloCapaVerde = 0;
    private int modeloCapaMago = 0;



    private int totalMoneda = 0;
    private int totalPuntaje = 0;
    private int totalComida = 0;


    private int totalPescado = 0;
    private int totalSushi = 0;
    private int totalHamburguesa = 0;

    private int cv_comprada = 0;
    private int cc_comprada = 0;
    private int cm_comprada = 0;
    private int pna_comprada = 0;
    private int pne_comprada = 0;

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

        cv_comprada = PlayerPrefs.GetInt(CapaVerdeComprada, 0);
        cc_comprada = PlayerPrefs.GetInt(CapaCelesteComprada, 0);
        cm_comprada = PlayerPrefs.GetInt(CapaMagoComprada, 0);

        pna_comprada = PlayerPrefs.GetInt(PielNaranjaComprada, 0);
        pne_comprada = PlayerPrefs.GetInt(PielNegraComprada, 0);

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

    public void GuardarMaterial(int modeloPielBlanca, int modeloPielNaranja, int modeloPielNegra,
        int modeloCapaRoja, int modeloCapaCeleste, int modeloCapaVerde, int modeloCapaMago){
        PlayerPrefs.SetInt(ModeloPielBlanca, modeloPielBlanca);
        PlayerPrefs.SetInt(ModeloPielNaranja, modeloPielNaranja);
        PlayerPrefs.SetInt(ModeloPielNegra, modeloPielNegra);

        PlayerPrefs.SetInt(ModeloCapaRoja, modeloCapaRoja);
        PlayerPrefs.SetInt(ModeloCapaCeleste, modeloCapaCeleste);
        PlayerPrefs.SetInt(ModeloCapaVerde, modeloCapaVerde);
        PlayerPrefs.SetInt(ModeloCapaMago, modeloCapaMago);

        PlayerPrefs.Save();

    }

    public void GuardarCompras(int cv_comprada, int cc_comprada, int cm_comprada,
        int pna_comprada, int pne_comprada /*int g_comprado, int m_comprada*/ ){

        PlayerPrefs.SetInt(CapaVerdeComprada, cv_comprada);
        PlayerPrefs.SetInt(CapaCelesteComprada, cc_comprada);
        PlayerPrefs.SetInt(CapaMagoComprada, cm_comprada);

        PlayerPrefs.SetInt(PielNaranjaComprada, pna_comprada);
        PlayerPrefs.SetInt(PielNegraComprada, pne_comprada);

        PlayerPrefs.Save();
    }

    
    // Reiniciar el total de monedas (test unity)
    public void ReiniciarDatos()
    {
        totalMoneda = 0;
        totalComida = 0;

        totalPescado = 0;
        totalSushi = 0;
        totalHamburguesa = 0;

        cv_comprada = 0;
        cc_comprada = 0;
        cm_comprada = 0;

        pna_comprada = 0;
        pne_comprada = 0;
        
        PlayerPrefs.SetInt(TotalMonedaKey, totalMoneda);
        PlayerPrefs.SetInt(TotalComidaKey, totalComida);

        PlayerPrefs.SetInt(TotalPescadoKey, totalPescado);
        PlayerPrefs.SetInt(TotalSushiKey, totalPescado);
        PlayerPrefs.SetInt(TotalHamburguesaKey, totalPescado);


        PlayerPrefs.SetInt(CapaVerdeComprada, cv_comprada);
        PlayerPrefs.SetInt(CapaCelesteComprada, cc_comprada);
        PlayerPrefs.SetInt(CapaMagoComprada, cm_comprada);

        PlayerPrefs.SetInt(PielNaranjaComprada, pna_comprada);
        PlayerPrefs.SetInt(PielNegraComprada, pne_comprada);



        PlayerPrefs.Save(); // Guardar los cambios



        print("--- REINICIO DATOS PLAYER PREFS ---");
        print("monedas: "+totalMoneda.ToString()+", pescado: "+totalPescado.ToString()+", sushi: "+totalSushi.ToString()+", hamburg: "+totalHamburguesa.ToString());
    }
}


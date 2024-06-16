using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorMonedas : MonoBehaviour
{

    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textMonedasDerrota;

    public int contador;

    private GuardadoManager guardadoManager;

    /**S
     ** Variables para guardar moneda
     **/
    //private int monedaTotal = 0;

    void Start() {
        guardadoManager = FindObjectOfType<GuardadoManager>();
        textoContador = GetComponent<TextMeshProUGUI>();
        contador = 0;
        ActualizarTexto();
    }
    //* Suma Monedas actualizando el contador y agregando monedas en PlayerPrefs. Mostrando por Pantalla
    public void Sumar(int cantidad) {
        contador = contador + cantidad;
        ActualizarTexto();
        guardadoManager.agregarMoneda(cantidad);
    }

    //POR el momento algo visual nada mas
    public void Restar(int cantidad)
    {
        contador -= cantidad;
        ActualizarTexto();
    }

    public void ActualizarTexto(){
        // Actualizar el texto del contador de monedas
        textoContador.text = " " + contador.ToString();
        textMonedasDerrota.text = " " + contador.ToString();
    }

    public int GetContador(){
        return contador;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorMonedas : MonoBehaviour
{
    
   public TextMeshProUGUI textoContador;
   
   public int contador = 0;

   /**
    ** Variables para guardar moneda
    **/
   private int monedaTotal = 0;
   private GuardadoManager guardarMoneda;

    void Start(){
        textoContador = GetComponent<TextMeshProUGUI>();
    }

    public void Sumar(int cantidad){
        contador = contador + cantidad;
        monedaTotal += contador;
        ActualizarTexto();
    }

    public void ActualizarTexto(){
        // Actualizar el texto del contador de monedas
        textoContador.text = contador.ToString();
    }

    public void GuardarMoneda(){
        guardarMoneda.aniadirMoneda(monedaTotal);
        monedaTotal = 0;
    }
}

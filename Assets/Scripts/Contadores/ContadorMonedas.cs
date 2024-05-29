using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorMonedas : MonoBehaviour
{
    
   public TextMeshProUGUI textoContador;
   public TextMeshProUGUI textMonedasDerrota;
   
   public int contador = 0;

   private GuardadoManager guardadoManager;

   /**S
    ** Variables para guardar moneda
    **/
   //private int monedaTotal = 0;

    void Start(){
        guardadoManager = FindObjectOfType<GuardadoManager>();
        textoContador = GetComponent<TextMeshProUGUI>();
        contador = 0;
        ActualizarTexto();
    }

    public void Sumar(int cantidad){
        contador = contador + cantidad;
        ActualizarTexto();
        guardadoManager.agregarMoneda(cantidad);

        
    }

    public void ReiniciarContador(){
        textMonedasDerrota.text = " " + contador.ToString();
        contador = 0;
        ActualizarTexto();
    }

    public void ActualizarTexto(){
        // Actualizar el texto del contador de monedas
        textoContador.text = " " + contador.ToString();
    }

    // No es necesario
    /*
    public void GuardarMoneda(){
        agregarMoneda(contador);
        //monedaTotal = 0;
    }
    */
}

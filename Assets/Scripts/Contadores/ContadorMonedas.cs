using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorMonedas : MonoBehaviour
{
    
   public TextMeshProUGUI textoContador;
   
   public int contador = 0;

    void Start(){
        textoContador = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

    }

    public void Sumar(){
        contador++;
        ActualizarTexto();
    }

    public void ActualizarTexto(){

         // Actualizar el texto del contador de monedas
        textoContador.text = contador.ToString();
    }
}

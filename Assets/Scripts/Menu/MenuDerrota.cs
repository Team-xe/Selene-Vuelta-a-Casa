using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MenuDerrota : MonoBehaviour
{
    public TextMeshProUGUI puntajetextMesh;
    public TextMeshProUGUI monedastextMesh;
    public Puntaje puntajePartida;
    public ContadorMonedas contadorMonedas;
    public float puntaje;
    public int monedas;
    

    void Start(){
        monedas = contadorMonedas.GetContador();
    }
    public void MostrarContadores()
    {
        // Obtener el puntaje del controlador de juego y mostrarlo en el objeto de texto
        //puntajetextMesh.text = "" + puntajePartida.asignarPuntaje(puntaje).ToString()     ;  
        //monedastextMesh.text = "" + monedas.ToString();         
    }
}

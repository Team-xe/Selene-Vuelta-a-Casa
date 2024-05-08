using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;
    private bool jugadorVivo = true; //indica si el jugador está vivo

    public MenuDerrota puntajeMenu;


    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); //inicializa el contador
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorVivo)
        {
            puntos += Time.deltaTime * 5;
            textMesh.text = " " + puntos.ToString("0");
        }

    }

    // Método que se llamar cuando el jugador muere
    public void JugadorMuerto()
    {
        jugadorVivo = false; //  false cuando el jugador muere
        //puntajeMenu.MostrarPuntaje();
       
    }
    
    public float asignarPuntaje(float asignar){
        asignar = puntos;
        return asignar;
    }
}
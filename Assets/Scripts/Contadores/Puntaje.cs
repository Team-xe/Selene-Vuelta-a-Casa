using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;
    public TextMeshProUGUI textPuntajeDerrota;
    private bool jugadorVivo = true; //indica si el jugador está vivo

    public MenuDerrota puntajeMenu;


    /**
    ** Variable par guardar puntaje
    **/
    private int PuntajeTotal = 0;
    private GuardadoManager guardarPuntaje;


    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); //inicializa el contador
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorVivo)
        {
            puntos += Time.deltaTime * 2;
            textMesh.text = " " + puntos.ToString("0");
        }
        if (!jugadorVivo){
            textPuntajeDerrota.text = " " + puntos.ToString("0");
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

    //! NO IMPLEMENTADO AÚN
    /*
    public void GuardarPuntaje(){
        guardarPuntaje.agregarPuntaje(PuntajeTotal);
        PuntajeTotal = 0;
    }
    */
}
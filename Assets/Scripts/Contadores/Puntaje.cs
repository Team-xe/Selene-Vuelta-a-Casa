using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;
    public TextMeshProUGUI textPuntajeDerrota;
    private bool jugadorVivo = true; //indica si el jugador está vivo

    public MenuDerrota puntajeMenu;

    /**
    ** Variable para guardar puntaje
    **/
    private int PuntajeTotal = 0;
    private GuardadoManager guardadoManager;
    private int finalAlcanzado;


    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); //inicializa el contador
        guardadoManager = FindObjectOfType<GuardadoManager>();
        finalAlcanzado = PlayerPrefs.GetInt("FinalDesbloqueado");
    }

    //* Se actualiza el texto de Puntos y el texto Puntos de la pantalla Derrota
    void Update()
    {
        if (jugadorVivo)
        {
            puntos += Time.deltaTime * 2;
            textMesh.text = " " + puntos.ToString("0");

            if (puntos > 500 && finalAlcanzado != 1)
            {
                finalAlcanzado = 1;
                guardadoManager.GuardarFinal(finalAlcanzado);
                SceneManager.LoadScene("Ganar");
            }
        }

    }

    // Método que se llama cuando el jugador muere
    public void JugadorMuerto()
    {
        jugadorVivo = false; //  false cuando el jugador muere  
        textPuntajeDerrota.text = " " + puntos.ToString("0");
    }

    public void JugadorVivo()
    {
        jugadorVivo = true;
    }

    /*
    public float asignarPuntaje(float asignar){
        asignar = puntos;
        return asignar;
    }
    */
}
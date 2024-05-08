using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MenuDerrota : MonoBehaviour
{
    public TextMeshProUGUI puntajetextMesh;
    private Puntaje puntajePartida;
    float puntaje;
    

    public void MostrarPuntaje()
    {
        // Obtener el puntaje del controlador de juego y mostrarlo en el objeto de texto
        puntajetextMesh.text = "" + puntajePartida.asignarPuntaje(puntaje).ToString();       
    }

    /**
    * Metodo para el boton Menu
    **/
    public void MenuInicial(){
        SceneManager.LoadScene("Menu Inicial");
    }

    /**
    * Metodo para el boton reiniciar
    **/
    public void reiniciar(){
        Invoke("Reiniciar",1);
    }

    /**
    * Metodo para el boton reiniciar
    **/
    public void Tienda(){
        SceneManager.LoadScene("Menu Tienda");
    }


    /**
    * Metodo para reiniciar la escena actual
    **/
    void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}

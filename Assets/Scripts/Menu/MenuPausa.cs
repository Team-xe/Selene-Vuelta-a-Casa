using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;


    //* Pausar Partida
    public void Pausa(){
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }

    //* Reanudar Partida
    public void Reanudar(){
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);

    }

    //* Reiniciar Partida
    public void Reiniciar(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Partida");
    }

    //* Menu Inicial
    public void Volver(){
        SceneManager.LoadScene("Menu Inicial");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //* Partida
    public void Jugar(){
        SceneManager.LoadScene("Partida");
    }

    //* Campamento
    public void Campamento(){
        SceneManager.LoadScene("Campamento");
    }

    //* Menu Tienda
    public void Tienda(){
        SceneManager.LoadScene("Menu Tienda");
    }

    //* Menu Inicial
    public void Volver(){
        SceneManager.LoadScene("Menu Inicial");
    }

    //* SALIR  
    public void Salir(){
        Debug.Log("Saliendo..");
        Application.Quit();
    }
}


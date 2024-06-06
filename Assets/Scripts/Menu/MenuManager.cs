using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void SaltarIntro(){
        Invoke("MenuInicial",1f);
        print("Saltando Intro...");
    }

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
    public void MenuInicial(){
        SceneManager.LoadScene("Menu Inicial");
    }

    //*Metodo para reiniciar la escena actual
    public void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //* SALIR  
    public void Salir(){
        Debug.Log("Saliendo..");
        Application.Quit();
    }
}


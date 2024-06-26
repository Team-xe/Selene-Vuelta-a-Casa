using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public Material SkyboxMaterial;
    public Color fondoReset;
    private GuardadoManager guardadoManager;

    public void Start(){
        SkyboxMaterial.SetColor("_Tint", fondoReset);
        RenderSettings.skybox = SkyboxMaterial;
        guardadoManager = FindObjectOfType<GuardadoManager>();
    }

    public void SaltarIntro(){
        Invoke("MenuInicial",1f);
        print("Saltando Intro...");
    }

    //* Partida
    public void Jugar(){
        //perder comida
        guardadoManager.agregarComida(-1);
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

    public void Multijugador()
    {
        //perder comida
        guardadoManager.agregarComida(-1);
        SceneManager.LoadScene("Multijugador");
    }


    //PARA PROBAR LUEGO SE PUEDE UTILIZAR OTRO CONTROLADOR O NOSE
    

    //* SALIR  
    public void Salir(){
        Debug.Log("Saliendo..");
        Application.Quit();
    }
}


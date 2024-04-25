using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
  public void Jugar(){
    SceneManager.LoadScene("Partida");
  }

  public void Tienda(){
    SceneManager.LoadScene("Menu Tienda");
  }

/*
  public void Multijugador(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
  }
  */


  
  public void Salir(){
      Debug.Log("Saliendo..");
      Application.Quit();
  }

  public void Volver(){
    SceneManager.LoadScene("Menu Inicial");
  }
}

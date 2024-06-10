using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private Slider _EfectoSlider, _MenuSlider;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //* Menu Inicial
    public void Volver(){
        SceneManager.LoadScene("Menu Inicial");
    }

    public void EfectosVolumen()
    {
        AudioManager.instance.CambiarVolumenEfectos(_EfectoSlider.value);
    }

    public void MenuVolumen()
    {
        AudioManager.instance.CambiarVolumenMenu(_MenuSlider.value);
    }
}

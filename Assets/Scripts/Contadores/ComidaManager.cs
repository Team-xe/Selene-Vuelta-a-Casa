using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class ComidaManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPescados;
    public TextMeshProUGUI textMeshSushis;
    public TextMeshProUGUI textMeshHamburguesas;
    public TextMeshProUGUI textMeshComida;

    private GuardadoManager guardadoManager;

    public int cantSushis = 0;
    public int cantHamburguesas = 0;
    public int cantPescados = 0;

    //* Barra de comida
    public int cantComida = 0;
    public ParticleSystem corazones;
    public AudioSource audioSource;
    public AudioSource gatito;

    public GameObject fondoDormir;
    public PlayableDirector controladorLineaTiempo;

    void Start()
    {
        guardadoManager = FindObjectOfType<GuardadoManager>();

        cantComida = PlayerPrefs.GetInt("TotalComidaKey");

        cantPescados = PlayerPrefs.GetInt("TotalPescadoKey");
        cantSushis = PlayerPrefs.GetInt("TotalSushiKey");
        cantHamburguesas = PlayerPrefs.GetInt("TotalHamburguesaKey");

        textMeshComida.text = cantComida.ToString()+"/100";
        textMeshPescados.text = "x"+ cantPescados.ToString();
        textMeshSushis.text = "x"+ cantSushis.ToString();
        textMeshHamburguesas.text = "x"+ cantHamburguesas.ToString();
        ActualizarTextos();
    }

    public void ComerPescado(){
        if (cantPescados > 0 && cantComida <= 99){
            cantPescados = cantPescados - 1;
            Comer(1);
            guardadoManager.agregarPescado(-1);
            corazones.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            corazones.Play();
            audioSource.Play();
        }
    }

    public void ComerSushi(){
        if (cantSushis > 0 && cantComida <= 95){
            cantSushis = cantSushis - 1;
            Comer(5);
            guardadoManager.agregarSushi(-1);
            corazones.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            corazones.Play();
            audioSource.Play();
        }
    }

    public void ComerHamburguesa(){
        if (cantHamburguesas > 0 && cantComida <= 85){
            cantHamburguesas = cantHamburguesas - 1;
            Comer(15);
            guardadoManager.agregarHamburguesa(-1);
            corazones.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            corazones.Play();
            audioSource.Play();
        }
    }

    public void Comer(int comida){
        guardadoManager.agregarComida(comida);

        cantComida = cantComida + comida;
        ActualizarTextos();
    }

    public void ActualizarTextos(){
        textMeshComida.text = cantComida.ToString()+"/100";

        textMeshPescados.text = "x"+ cantPescados.ToString();
        textMeshSushis.text = "x"+ cantSushis.ToString();
        textMeshHamburguesas.text = "x"+ cantHamburguesas.ToString();
    }

    public void Dormir(){

        //TODO: Pantalla en negro y sonido Zzz
        fondoDormir.SetActive(true);
        controladorLineaTiempo.Play();
        gatito.Play();
        
        Invoke("Despertar",6f);

    }

    
    public void Despertar(){
        if (cantComida <= 0){
            Comer(1);
        }
        gatito.Stop();
        fondoDormir.SetActive(false);
    }
    

    void Update()
    {
        
    }
}

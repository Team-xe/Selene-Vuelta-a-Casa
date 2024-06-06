using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    }

    public void ComerPescado(){
        if (cantPescados > 0){
            cantPescados = cantPescados - 1;
            Comer(1);
            guardadoManager.agregarPescado(-1);
        }
    }

    public void ComerSushi(){
        if (cantSushis > 0){
            cantSushis = cantSushis - 1;
            Comer(5);
            guardadoManager.agregarSushi(-1);
        }
    }

    public void ComerHamburguesa(){
        if (cantHamburguesas > 0){
            cantHamburguesas = cantHamburguesas - 1;
            Comer(15);
            guardadoManager.agregarHamburguesa(-1);
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

    void Update()
    {
        
    }
}

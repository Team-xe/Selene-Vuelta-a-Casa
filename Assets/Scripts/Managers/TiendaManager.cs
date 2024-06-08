using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TiendaManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshMonedas;

    public TextMeshProUGUI textMeshPescados;
    public TextMeshProUGUI textMeshSushis;
    public TextMeshProUGUI textMeshHamburguesas;

    private GuardadoManager guardadoManager;
    int cantmonedas = 0;
    int cantPescados = 0;
    int cantSushis = 0;
    int cantHamburguesas = 0;


    // Start is called before the first frame update
    void Start()
    {
        guardadoManager = FindObjectOfType<GuardadoManager>();
        
        cantmonedas = PlayerPrefs.GetInt("TotalMonedaKey");

        cantPescados = PlayerPrefs.GetInt("TotalPescadoKey");
        cantSushis = PlayerPrefs.GetInt("TotalSushiKey");
        cantHamburguesas = PlayerPrefs.GetInt("TotalHamburguesasKey");

        textMeshMonedas.text = " "+ cantmonedas.ToString();

        textMeshPescados.text = "x"+ cantPescados.ToString();
        textMeshSushis.text = "x"+ cantSushis.ToString();
        textMeshHamburguesas.text = "x"+ cantHamburguesas.ToString();
    }

    public void ActualizarTextoMonedas(){
        textMeshMonedas.text = " "+ cantmonedas.ToString();
    }
    public void ActualizarTextoPescado(){
        textMeshPescados.text = "x"+ cantPescados.ToString();
    }
    public void ActualizarTextoSushi(){
        textMeshSushis.text = "x"+ cantSushis.ToString();
    }
    public void ActualizarTextoHamburguesa(){
        textMeshHamburguesas.text = "x"+ cantHamburguesas.ToString();
    }
    

    public void ComprarPescado(){
        guardadoManager.agregarPescado(1);
        cantPescados = cantPescados + 1;
        Cobrar(1);
        ActualizarTextoPescado();
    }

    public void ComprarSushi(){
        guardadoManager.agregarSushi(1);
        cantSushis = cantSushis + 1;
        Cobrar(5);
        ActualizarTextoSushi();
    }

    public void ComprarHamburguesa(){
        guardadoManager.agregarHamburguesa(1);
        cantHamburguesas = cantHamburguesas + 1;
        Cobrar(10);
        ActualizarTextoHamburguesa();
    }

    public void ComprarCapa(){
        Cobrar(50);
    }
    public void ComprarCapaMagica(){
        Cobrar(80);
    }
    public void ComprarPiel(){
        Cobrar(50);
    }
    public void ComprarGorro(){
        Cobrar(50);
    }

    public void ComprarMejora(){
        Cobrar(50);
    }

    public void GanarDinero(){
        Cobrar(-50);
    }

    public void Cobrar(int precio){
        if (cantmonedas >= precio){
            AudioManager.instance.ReproducirEfectos("Compra");
            guardadoManager.agregarMoneda(-precio);

            cantmonedas = cantmonedas - precio;
            ActualizarTextoMonedas();
        }
    }
}

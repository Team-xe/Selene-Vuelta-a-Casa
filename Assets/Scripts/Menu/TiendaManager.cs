using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TiendaManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    private GuardadoManager guardadoManager;
    int cantmonedas = 0;


    // Start is called before the first frame update
    void Start()
    {
        guardadoManager = FindObjectOfType<GuardadoManager>();
        cantmonedas = PlayerPrefs.GetInt("TotalMonedaKey");
        textMesh.text = " "+ cantmonedas.ToString();
    }

    public void ActualizarTexto(){
        textMesh.text = " "+ cantmonedas.ToString();
    }

    public void ComprarPescado(){
        Cobrar(1);
    }

    public void ComprarSushi(){
        Cobrar(5);
    }

    public void ComprarHamburguesa(){
        Cobrar(10);
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
            guardadoManager.agregarMoneda(-precio);
            cantmonedas = cantmonedas - precio;
            ActualizarTexto();
        }
    }
}

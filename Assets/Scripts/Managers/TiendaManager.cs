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

        cv_comprada = PlayerPrefs.GetInt("CapaVerdeComprada");
        cc_comprada = PlayerPrefs.GetInt("CapaCelesteComprada");
        cm_comprada = PlayerPrefs.GetInt("CapaMagoComprada");
        pna_comprada = PlayerPrefs.GetInt("PielNaranjaComprada");
        pne_comprada = PlayerPrefs.GetInt("PielNegraComprada");
        poder_comprado = PlayerPrefs.GetInt("PoderComprado");
        //TODO: g_comprado aqui y en el GuardadoManager


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
        if (cantmonedas >= 1){
            guardadoManager.agregarPescado(1);
            cantPescados = cantPescados + 1;
            Cobrar(1);
            ActualizarTextoPescado();
        }
    }

    public void ComprarSushi(){
        if (cantmonedas >= 5){
            guardadoManager.agregarSushi(1);
            cantSushis = cantSushis + 1;
            Cobrar(5);
            ActualizarTextoSushi();
        }
    }

    public void ComprarHamburguesa(){
        if (cantmonedas >= 10){
            guardadoManager.agregarHamburguesa(1);
            cantHamburguesas = cantHamburguesas + 1;
            Cobrar(10);
            ActualizarTextoHamburguesa();
        }
        
    }


    
    //* Cosmeticos --------------------------------------
    public int cv_comprada = 0; // capa verde
    public int cc_comprada = 0; // capa celeste
    public int cm_comprada = 0; // capa mago
    public int pna_comprada = 0; // piel naranja
    public int pne_comprada = 0; // piel negra
    public int g_comprado = 0; // TODO: Implementar  gorro
    public int poder_comprado = 0; // mejora
    
    public void ComprarCapaVerde(){
        if (cv_comprada == 0 && cantmonedas >= 50){
            Cobrar(50);
            cv_comprada = 1;
            guardadoManager.GuardarCompras(cv_comprada, cc_comprada, cm_comprada, pna_comprada, pne_comprada, poder_comprado);
        }
    }
    public void ComprarCapaCeleste(){
        if (cc_comprada == 0 && cantmonedas >= 50){
            Cobrar(50);
            cc_comprada = 1;
            guardadoManager.GuardarCompras(cv_comprada, cc_comprada, cm_comprada, pna_comprada, pne_comprada, poder_comprado);
        }
    }
    public void ComprarCapaMagica(){
        if (cm_comprada == 0 && cantmonedas >= 80){
            Cobrar(80);
            cm_comprada = 1;
            guardadoManager.GuardarCompras(cv_comprada, cc_comprada, cm_comprada, pna_comprada, pne_comprada, poder_comprado);
        }
    }
    
    public void ComprarPielNaranja(){
        if (pna_comprada == 0 && cantmonedas >= 50){
            Cobrar(50);
            pna_comprada = 1;
            guardadoManager.GuardarCompras(cv_comprada, cc_comprada, cm_comprada, pna_comprada, pne_comprada, poder_comprado);
        }
    }
    
    public void ComprarPielNegra(){
        if (pne_comprada == 0 && cantmonedas >= 50){
            Cobrar(50);
            pne_comprada = 1;
            guardadoManager.GuardarCompras(cv_comprada, cc_comprada, cm_comprada, pna_comprada, pne_comprada, poder_comprado);
        }
    }
    
    public void ComprarGorro(){
        if (g_comprado == 0 && cantmonedas >= 50){
            Cobrar(50);
            g_comprado = 1;
            guardadoManager.GuardarCompras(cv_comprada, cc_comprada, cm_comprada, pna_comprada, pne_comprada, poder_comprado);
        }
    }

    
    public void ComprarMejora(){
        if (poder_comprado == 0 && cantmonedas >= 50){
            Cobrar(50);
            poder_comprado = 1;
            guardadoManager.GuardarCompras(cv_comprada, cc_comprada, cm_comprada, pna_comprada, pne_comprada, poder_comprado);
        }
    }

    public void GanarDinero(){
        Cobrar(-50);
    }

    public void Cobrar(int precio){
        print(cantmonedas);
        if (cantmonedas >= precio){
            AudioManager.instance.ReproducirEfectos("Compra");
            guardadoManager.agregarMoneda(-precio);
            print(cantmonedas);
            cantmonedas = cantmonedas - precio;
            ActualizarTextoMonedas();
        }
    }
}

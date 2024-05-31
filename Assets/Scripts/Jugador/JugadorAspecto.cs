using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAspecto : MonoBehaviour
{
    // Variables publicas para asignar texturas desde el inspector

    public Texture blancoCapaRoja;
    public Texture blancoCapaCeleste;
    public Texture blancoCapaVerde;
    public Texture blancoCapaMago;

    public Texture naranjaCapaRoja;
    public Texture naranjaCapaCeleste;
    public Texture naranjaCapaVerde;
    public Texture naranjaCapaMago;

    public Texture negroCapaRoja;
    public Texture negroCapaCeleste;
    public Texture negroCapaVerde;
    public Texture negroCapaMago;

    public GameObject[] capas;

    public bool capaRoja = true;
    public bool capaCeleste = false;
    public bool capaVerde = false;
    public bool capaMago = false;

    public bool pielBlanca = true;
    public bool pielNaranja = false;

    public bool pielNegra = false;

    public int capaActual = 0;





    // Variable para almacenar el material "Selene"
    public Material materialSelene;

    void Start()
    {
        pielBlanca = true;
        pielNaranja = false;
        pielNegra = false;
        capaRoja = true;
        capaCeleste = false;
        capaMago = false;
        capaVerde = false;
        capaActual = 0;
        // Cargar el material "Selene" desde la carpeta Assets
        //materialSelene = Resources.Load<Material>("Selene");
    }

    public void PielBlanca(){
        pielNaranja = false;
        pielNegra = false;

        pielBlanca = true;
    }
    public void PielNaranja(){
        pielBlanca = false;
        pielNegra = false;

        pielNaranja = true;
    }
    public void PielNegra(){
        pielBlanca = false;
        pielNaranja = false;

        pielNegra = true;
    }

    //* Metodo para ir cambiando de capa en la UI del Campamento
    public void CambiarCapa(){
        if (capaActual == 3){
            capaActual = 0;
        }
        else {
            capaActual++;
        }

        // Desactivar el resto de capas
        for (int i=0; i<=3; i++){
            capas[i].SetActive(false);
        }

        // Capa que se ve
        capas[capaActual].SetActive(true);

        capaRoja = false;
        capaCeleste = false;
        capaVerde = false;
        capaMago = false;

        if (capaActual == 0){
            capaRoja = true;
        }
        if (capaActual == 1){
            capaCeleste = true;
        }
        if (capaActual == 2){
            capaVerde = true;
        }
        if (capaActual == 3){
            capaMago = true;
        }
        
    }

    void Update(){

        if (pielBlanca == true){
            if (capaRoja == true){
                CambiarTextura(blancoCapaRoja);
            }
            if (capaCeleste == true){
                CambiarTextura(blancoCapaCeleste);
            }
            if (capaVerde == true){
                CambiarTextura(blancoCapaVerde);
            }
            if (capaMago == true){
                CambiarTextura(blancoCapaMago);
            }
        }

        if (pielNaranja == true){
            if (capaRoja == true){
                CambiarTextura(naranjaCapaRoja);
            }
            if (capaCeleste == true){
                CambiarTextura(naranjaCapaCeleste);
            }
            if (capaVerde == true){
                CambiarTextura(naranjaCapaVerde);
            }
            if (capaMago == true){
                CambiarTextura(naranjaCapaMago);
            }

        }
        

        if (pielNegra == true){
            if (capaRoja == true){
                CambiarTextura(negroCapaRoja);
            }
            if (capaCeleste == true){
                CambiarTextura(negroCapaCeleste);
            }
            if (capaVerde == true){
                CambiarTextura(negroCapaVerde);
            }
            if (capaMago == true){
                CambiarTextura(negroCapaMago);
            }
        }
        

    }

    //* Metodo para cambiar la textura del jugador
    public void CambiarTextura(Texture textura)
    {
        materialSelene.SetTexture("_MainTex", textura);
    }
}

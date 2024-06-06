using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAspecto : MonoBehaviour
{
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

    public int pielBlanca = 1;
    public int pielNaranja = 0;
    public int pielNegra = 0;

    public int capaRoja = 1;
    public int capaCeleste = 0;
    public int capaVerde = 0;
    public int capaMago = 0;

    public int capaActual = 0;

    private GuardadoManager guardadoManager;

    public Material materialSelene;

    void Start()
    {
        guardadoManager = FindObjectOfType<GuardadoManager>();

        pielBlanca = PlayerPrefs.GetInt("ModeloPielBlanca", 1);
        pielNaranja = PlayerPrefs.GetInt("ModeloPielNaranja", 0);
        pielNegra = PlayerPrefs.GetInt("ModeloPielNegra", 0);
        capaRoja = PlayerPrefs.GetInt("ModeloCapaRoja", 1);
        capaCeleste = PlayerPrefs.GetInt("ModeloCapaCeleste", 0);
        capaVerde = PlayerPrefs.GetInt("ModeloCapaVerde", 0);
        capaMago = PlayerPrefs.GetInt("ModeloCapaMago", 0);

        capaActual = PlayerPrefs.GetInt("CapaActual", 0);

        materialSelene = Resources.Load<Material>("Selene");

        if (pielBlanca == 0 && pielNaranja == 0 && pielNegra == 0){
            pielBlanca = 1;
        }
        if (capaRoja == 0 && capaCeleste == 0 && capaVerde == 0 && capaMago == 0){
            capaRoja = 1;
        }

        ActualizarTextura();
    }

    public void PielBlanca(){
        pielNaranja = 0;
        pielNegra = 0;
        pielBlanca = 1;
        ActualizarTextura();
    }
    public void PielNaranja(){
        pielBlanca = 0;
        pielNegra = 0;
        pielNaranja = 1;
        ActualizarTextura();
    }
    public void PielNegra(){
        pielBlanca = 0;
        pielNaranja = 0;
        pielNegra = 1;
        ActualizarTextura();
    }

    public void CambiarCapa(){
        capaActual = (capaActual + 1) % capas.Length;

        for (int i = 0; i < capas.Length; i++){
            capas[i].SetActive(i == capaActual);
        }

        capaRoja = capaActual == 0 ? 1 : 0;
        capaCeleste = capaActual == 1 ? 1 : 0;
        capaVerde = capaActual == 2 ? 1 : 0;
        capaMago = capaActual == 3 ? 1 : 0;

        ActualizarTextura();
    }

    void Update(){
        
    }

    private void ActualizarTextura()
    {
        Texture nuevaTextura = null;

        if (pielBlanca == 1){
            if (capaRoja == 1) nuevaTextura = blancoCapaRoja;
            if (capaCeleste == 1) nuevaTextura = blancoCapaCeleste;
            if (capaVerde == 1) nuevaTextura = blancoCapaVerde;
            if (capaMago == 1) nuevaTextura = blancoCapaMago;
        } else if (pielNaranja == 1){
            if (capaRoja == 1) nuevaTextura = naranjaCapaRoja;
            if (capaCeleste == 1) nuevaTextura = naranjaCapaCeleste;
            if (capaVerde == 1) nuevaTextura = naranjaCapaVerde;
            if (capaMago == 1) nuevaTextura = naranjaCapaMago;
        } else if (pielNegra == 1){
            if (capaRoja == 1) nuevaTextura = negroCapaRoja;
            if (capaCeleste == 1) nuevaTextura = negroCapaCeleste;
            if (capaVerde == 1) nuevaTextura = negroCapaVerde;
            if (capaMago == 1) nuevaTextura = negroCapaMago;
        }

        CambiarTextura(nuevaTextura);
    }

    public void CambiarTextura(Texture textura)
    {
        print("CambiarTextura()");
        if (materialSelene != null && textura != null)
        {
            print("CambiarTextura() se aplica");
            materialSelene.SetTexture("_MainTex", textura);
        }
    }
}

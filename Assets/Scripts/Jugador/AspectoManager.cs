using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectoManager : MonoBehaviour
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

    private int capaRoja;
    private int capaCeleste;
    private int capaVerde;
    private int capaMago;

    private int pielBlanca;
    private int pielNaranja;
    private int pielNegra;

    private GuardadoManager guardadoManager;

    // Variable para almacenar el material "Selene"
    private Material materialSelene;

    void Start()
    {
        guardadoManager = FindObjectOfType<GuardadoManager>();

        // Cargar valores desde PlayerPrefs sin valores predeterminados
        pielBlanca = PlayerPrefs.GetInt("ModeloPielBlanca");
        pielNaranja = PlayerPrefs.GetInt("ModeloPielNaranja");
        pielNegra = PlayerPrefs.GetInt("ModeloPielNegra");
        capaRoja = PlayerPrefs.GetInt("ModeloCapaRoja");
        capaCeleste = PlayerPrefs.GetInt("ModeloCapaCeleste");
        capaVerde = PlayerPrefs.GetInt("ModeloCapaVerde");
        capaMago = PlayerPrefs.GetInt("ModeloCapaMago");

        // Cargar el material "Selene" desde la carpeta Resources
        materialSelene = Resources.Load<Material>("Selene");

        // Verificar que al menos una piel y una capa esté seleccionada
        if (pielBlanca == 0 && pielNaranja == 0 && pielNegra == 0)
        {
            pielBlanca = 1;
            print("pielBlanca sera 1 porque todas eran 0");
        }
        if (capaRoja == 0 && capaCeleste == 0 && capaVerde == 0 && capaMago == 0)
        {
            capaRoja = 1;
            print("capaRoja sera 1 porque todas eran 0");
        }

        ActualizarTextura();
    }

    void Update()
    {
        
    }

    private void ActualizarTextura()
    {
        Texture nuevaTextura = null;

        if (pielBlanca == 1)
        {
            if (capaRoja == 1) nuevaTextura = blancoCapaRoja;
            if (capaCeleste == 1) nuevaTextura = blancoCapaCeleste;
            if (capaVerde == 1) nuevaTextura = blancoCapaVerde;
            if (capaMago == 1) nuevaTextura = blancoCapaMago;
        }
        else if (pielNaranja == 1)
        {
            if (capaRoja == 1) nuevaTextura = naranjaCapaRoja;
            if (capaCeleste == 1) nuevaTextura = naranjaCapaCeleste;
            if (capaVerde == 1) nuevaTextura = naranjaCapaVerde;
            if (capaMago == 1) nuevaTextura = naranjaCapaMago;
        }
        else if (pielNegra == 1)
        {
            if (capaRoja == 1) nuevaTextura = negroCapaRoja;
            if (capaCeleste == 1) nuevaTextura = negroCapaCeleste;
            if (capaVerde == 1) nuevaTextura = negroCapaVerde;
            if (capaMago == 1) nuevaTextura = negroCapaMago;
        }

        CambiarTextura(nuevaTextura);
    }

    // Método para cambiar la textura del jugador
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

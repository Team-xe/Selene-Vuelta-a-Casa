using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectoManager : MonoBehaviour
{
    // Materiales para diferentes capas y colores de piel
    // Blanco
    public Material blancoCapaRoja;
    public Material blancoCapaCeleste;
    public Material blancoCapaVerde;
    public Material blancoCapaMago;
    
    // Naranja
    public Material naranjaCapaRoja;
    public Material naranjaCapaCeleste;
    public Material naranjaCapaVerde;
    public Material naranjaCapaMago;

    // Negro
    public Material negroCapaRoja;
    public Material negroCapaCeleste;
    public Material negroCapaVerde;
    public Material negroCapaMago;

    // Indices para controlar las texturas
    private int capaRoja;
    private int capaCeleste;
    private int capaVerde;
    private int capaMago;

    private int pielBlanca;
    private int pielNaranja;
    private int pielNegra;

    private GuardadoManager guardadoManager;

    public GameObject JugadorModelo;

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

        CambiarMaterialRecursivo(JugadorModelo.transform);
        //ActualizarTextura();
    }

    public void CambiarMaterialRecursivo(Transform transformActual){
        // Intentar obtener el componente Renderer del GameObject actual.
        Renderer renderer = transformActual.GetComponent<Renderer>();

        // Si tiene un componente Renderer, cambiar su material.
        if (renderer != null){
            // Aquí puedes agregar la lógica para decidir qué material aplicar
            if (pielBlanca == 1){
                if (capaRoja == 1)
                    renderer.material = blancoCapaRoja;
                else if (capaCeleste == 1)
                    renderer.material = blancoCapaCeleste;
                else if (capaVerde == 1)
                    renderer.material = blancoCapaVerde;
                else if (capaMago == 1)
                    renderer.material = blancoCapaMago;
            }
            
            else if (pielNaranja == 1){
                if (capaRoja == 1)
                    renderer.material = naranjaCapaRoja;
                else if (capaCeleste == 1)
                    renderer.material = naranjaCapaCeleste;
                else if (capaVerde == 1)
                    renderer.material = naranjaCapaVerde;
                else if (capaMago == 1)
                    renderer.material = naranjaCapaMago;
            }

            else if (pielNegra == 1){
                if (capaRoja == 1)
                    renderer.material = negroCapaRoja;
                else if (capaCeleste == 1)
                    renderer.material = negroCapaCeleste;
                else if (capaVerde == 1)
                    renderer.material = negroCapaVerde;
                else if (capaMago == 1)
                    renderer.material = negroCapaMago;
            }
            // Agregar lógica adicional para las otras combinaciones de piel y capas.
        }

        // Recorrer recursivamente todos los hijos del GameObject actual.
        foreach (Transform hijo in transformActual)
        {
            CambiarMaterialRecursivo(hijo);
        }
    }
}

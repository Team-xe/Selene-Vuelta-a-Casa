using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAspecto : MonoBehaviour
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

    public int pielBlanca = 1;
    public int pielNaranja = 0;
    public int pielNegra = 0;

    public int capaRoja = 1;
    public int capaCeleste = 0;
    public int capaVerde = 0;
    public int capaMago = 0;

    // Aspectos comprados o no (bool usando int)
    public int cv_comprada = 0;
    public int cc_comprada = 0;
    public int cm_comprada = 0;

    public int pna_comprada = 0;
    public int pne_comprada = 0;


    private GuardadoManager guardadoManager;

    public GameObject JugadorModelo;


    public GameObject cv_bloqueo;
    public GameObject cc_bloqueo;
    public GameObject cm_bloqueo;
    public GameObject pna_bloqueo;
    public GameObject pne_bloqueo;
    void Start()
    {
        guardadoManager = FindObjectOfType<GuardadoManager>();

        pielBlanca = PlayerPrefs.GetInt("ModeloPielBlanca", 0);
        pielNaranja = PlayerPrefs.GetInt("ModeloPielNaranja", 0);
        pielNegra = PlayerPrefs.GetInt("ModeloPielNegra", 0);
        capaRoja = PlayerPrefs.GetInt("ModeloCapaRoja", 0);
        capaCeleste = PlayerPrefs.GetInt("ModeloCapaCeleste", 0);
        capaVerde = PlayerPrefs.GetInt("ModeloCapaVerde", 0);
        capaMago = PlayerPrefs.GetInt("ModeloCapaMago", 0);

        cv_comprada = PlayerPrefs.GetInt("CapaVerdeComprada");
        cc_comprada = PlayerPrefs.GetInt("CapaCelesteComprada");
        cm_comprada = PlayerPrefs.GetInt("CapaMagoComprada");

        pna_comprada = PlayerPrefs.GetInt("PielNaranjaComprada");
        pne_comprada = PlayerPrefs.GetInt("PielNegraComprada");

        if (pielBlanca == 0 && pielNaranja == 0 && pielNegra == 0){
            pielBlanca = 1;
        }
        if (capaRoja == 0 && capaCeleste == 0 && capaVerde == 0 && capaMago == 0){
            capaRoja = 1;
        }

        CambiarMaterialRecursivo(JugadorModelo.transform);
        guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);

        if (cv_comprada == 1){
            cv_bloqueo.SetActive(false);
        }
        if (cc_comprada == 1){
            cc_bloqueo.SetActive(false);
        }
        if (cm_comprada == 1){
            cm_bloqueo.SetActive(false);
        }
        if (pna_comprada == 1){
            pna_bloqueo.SetActive(false);
        }
        if (pne_comprada == 1){
            pne_bloqueo.SetActive(false);
        }

    }

    public void PielBlanca(){
        pielNaranja = 0;
        pielNegra = 0;
        pielBlanca = 1;
        CambiarMaterialRecursivo(JugadorModelo.transform);
        guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);
    }
    public void PielNaranja(){
        if (pna_comprada == 1){
            pielBlanca = 0;
            pielNegra = 0;
            pielNaranja = 1;
            CambiarMaterialRecursivo(JugadorModelo.transform);
            guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);
        }
    }
    public void PielNegra(){
        if (pne_comprada == 1){
            pielBlanca = 0;
            pielNaranja = 0;
            pielNegra = 1;
            CambiarMaterialRecursivo(JugadorModelo.transform);
            guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);
        }
    }

    public void CapaRoja(){
        capaRoja = 1;
        capaCeleste = 0;
        capaVerde = 0;
        capaMago = 0;
        CambiarMaterialRecursivo(JugadorModelo.transform);
        guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);
    }



    public void CapaCeleste(){
        if (cc_comprada == 1){
            capaRoja = 0;
            capaCeleste = 1;
            capaVerde = 0;
            capaMago = 0;
            CambiarMaterialRecursivo(JugadorModelo.transform);
            guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);
        }
    }
    public void CapaVerde(){
        if (cv_comprada == 1){
            capaRoja = 0;
            capaCeleste = 0;
            capaVerde = 1;
            capaMago = 0;
            CambiarMaterialRecursivo(JugadorModelo.transform);
            guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);
        }
    }
    public void CapaMago(){
        if (cm_comprada == 1){
            capaRoja = 0;
            capaCeleste = 0;
            capaVerde = 0;
            capaMago = 1;
            CambiarMaterialRecursivo(JugadorModelo.transform);
            guardadoManager.GuardarMaterial(pielBlanca, pielNaranja, pielNegra, capaRoja, capaCeleste, capaVerde, capaMago);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject Suelos;

    public Material ArbolMaterial;
    public Material SueloMaterial;

    public Material ArbolReset;
    public Material SueloReset;
    public Material ArenaReset;

    
    public Material SkyboxMaterial;
    public Color fondoColor;
    public Color fondoReset;
    public Color fogReset;
    public Color fogColor;

    public GameObject monedaEspecialPrefab;

    void Start(){
        SkyboxMaterial.SetColor("_Tint", fondoReset);
        RenderSettings.skybox = SkyboxMaterial;
        RenderSettings.fogColor = fogReset;

        Suelos = GameObject.Find("Suelos Pool");
        if (Suelos == null){
            print("No se encontró Suelos Pool");
        }
    }

    public void ResetMaterial(){
        CambiarMaterial(1);
    }
    public void ReemplazarMonedas(){
        // Encontrar todos los objetos "MonedaOro(Clone)"
        GameObject[] monedasOro = GameObject.FindGameObjectsWithTag("Moneda");

        // Iterar sobre todas las monedas encontradas
        foreach (GameObject monedaOro in monedasOro)
        {
            // Obtener la posición de la moneda actual
            Vector3 posicion = monedaOro.transform.position;
            Quaternion rotacion = monedaOro.transform.rotation;

            // Instanciar una nueva "MonedaEspecial" en la misma posición
            GameObject nuevaMoneda = Instantiate(monedaEspecialPrefab, posicion, rotacion);

            // Destruir la moneda original
            Destroy(monedaOro);
        }
    }
    public void CambiarMaterial(int reset){
        // Iterar sobre todos los hijos del objeto Suelos
        foreach (Transform suelo in Suelos.transform){
            // Iterar sobre todos los hijos del objeto Suelo
            foreach (Transform hijo in suelo){

                if (hijo.name=="Arboles"){
                    foreach (Transform arbol in hijo){
                        Renderer rendererArb = arbol.GetComponent<Renderer>();
                        if (reset == 0){
                            
                            rendererArb.material = ArbolMaterial;
                        }
                        if (reset == 1){
                            rendererArb.material = ArbolReset;
                        }
                        
                    }
                }

                if (hijo.name == "PlanoIzq" || hijo.name == "PlanoDer"){
                    if (hijo.name!="PlanoAgujero"){
                        Renderer rendererSuelo = hijo.GetComponent<Renderer>();
                        if (reset == 0){
                            rendererSuelo.material = SueloMaterial;
                        }
                        if (reset == 1){
                            rendererSuelo.material = SueloReset;
                        }
                        
                    }
                }
                if (hijo.name=="Plano"){
                    if (hijo.name!="PlanoAgujero"){
                        Renderer rendererSuelo = hijo.GetComponent<Renderer>();
                        if (reset == 0){
                            rendererSuelo.material = SueloMaterial;
                        }
                        if (reset == 1){
                            rendererSuelo.material = ArenaReset;
                        }
                        
                    }

                }
            }
        }
        if (reset == 0){
            ReemplazarMonedas();
            SkyboxMaterial.SetColor("_Tint", fondoColor);
            RenderSettings.skybox = SkyboxMaterial;
            RenderSettings.fogColor = fogColor;
        }
        if (reset == 1){
            SkyboxMaterial.SetColor("_Tint", fondoReset);
            RenderSettings.skybox = SkyboxMaterial;
            RenderSettings.fogColor = fogReset;
        }
        if (reset == 0){
            Invoke("ResetMaterial",18f);
        }
    }
}

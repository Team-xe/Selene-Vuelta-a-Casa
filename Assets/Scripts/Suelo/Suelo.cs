using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
** Script para que cada Suelo aparezca con Obstaculos y sea Destruido cuando el Jugador ya deje de tocarlo creando otro al final en su lugar
**/
public class Suelo : MonoBehaviour
{
    //SuelosGenerador sueloGenerador; // Variable para guardar el Script que genera Suelos

    SuelosReciclador suelos; // Script para Object Pool de Suelos

    void Start()
    {
        //sueloGenerador = GameObject.FindObjectOfType<SuelosGenerador>(); // Guarda el Script SuelosGenerador (buscandolo)
        suelos = GameObject.FindObjectOfType<SuelosReciclador>(); // Guarda el Script SuelosGenerador (buscandolo)
        
        GenerarObstaculo(); // Suelo nace con 1 Obstaculo
        GenerarMoneda(); // Suelo nace con 1 Moneda
        GenerarEnemigo(); //
        GenerarPoder();
        AudioManager.instance.ReproducirMenu("MusicaFondo");
    }

    public void MoverSueloRetrasado(){
        suelos.MoverSuelo();
        LimpiarObjetosGenerados();
        
        GenerarObstaculo(); // Suelo nace con 1 Obstaculo
        GenerarMoneda(); // Suelo nace con 1 Moneda
        GenerarEnemigo(); //
        GenerarPoder();
    }

    public void LimpiarObjetosGenerados(){
        foreach (Transform child in transform){
            if (child.CompareTag("Enemigo") || child.CompareTag("Moneda") || child.CompareTag("Poder1") || child.CompareTag("Poder2") || child.CompareTag("Trampolin")){
                Destroy(child.gameObject);
            }
        }
    }
    /**
    ** Metodo que mueve este Suelo actual de este Script al salir de la Colision con algo 
    **/
    private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Jugador")){{
            Invoke("MoverSueloRetrasado",1.3f);
            //gameObject.SetActive(false);
            //sueloGenerador.GenerarSuelo(); // Accede al Script SuelosGenerador y Genera otro Suelo en alguna posicion
            //Destroy(gameObject,2); // Destruye 1 Suelo despues de 2 segundos

        }}
        
    }


    // Obstaculos
    public GameObject obstaculo1Prefab; // Caja
    public GameObject obstaculo2Prefab; // Tronco
    public GameObject obstaculo3Prefab; // Pajaro (volador)
    public GameObject obstaculo4Prefab; // Seta

    public GameObject monedaPrefab;
    public GameObject Enemigo1Prefab; // Ranita que salte
    public GameObject poder1Prefab; //EXPLOTA TODO
    public GameObject poder2Prefab; // Invulnerable

    int obstaculoGenIndex;
    int monedaGenIndex;
    int enemigoGenIndex;
    int poderGenIndex;

    public bool enemigoGenerado;

    /**
    ** Metodo para generar 1 o mas Obstaculos en un punto random entre los 3 gameobjects que marcan posiciones izq, medio, der de un Suelo
    **/
    void GenerarObstaculo(){

        //* Escoger un punto random (1,2,3) para generar el obstaculo

        // Numero random de posicion en carril (1,2,3)
        obstaculoGenIndex = Random.Range(2,5); // numero random
        // Guarda la posicion 1, 2 o 3 en "puntoGen"
        Transform puntoGen = transform.GetChild(obstaculoGenIndex).transform; // regresa el componente transform de uno de los 3 GameObjects obstaculoGen izq, medio, der
        

        //* Generar 1 de los 3 obstaculos en la posicion "puntoGen"

        float probabilidad = Random.Range (0f,1f); // probabilidad de uno u otro
    

        //* OPCIONES DE OBSTACULOS (solo se genera 1)

        // Obstaculo 1  30% (0.5 a 0.2) // Antes era 0.7 a 0.2 50% //* MURO
        if (probabilidad < 0.5f && probabilidad > 0.2){
            
            GameObject obstaculo = Instantiate(obstaculo1Prefab, puntoGen.position, obstaculo1Prefab.transform.rotation, obstaculo1Prefab.transform);
            obstaculo.transform.SetParent(transform);
        }

        // Obstaculo 3 (En el aire) 20% [0.3 a 0.1) //* PAJARO 0.1 0.2 0.3
        if (probabilidad <= 0.3f && probabilidad > 0.1f){
            Transform puntoAire = puntoGen;
            puntoAire.position = new Vector3(puntoGen.position.x, puntoGen.position.y + 2.5f, puntoGen.position.z);

            GameObject obstaculo = Instantiate(obstaculo3Prefab, puntoAire.position, obstaculo3Prefab.transform.rotation, obstaculo3Prefab.transform);
            obstaculo.transform.SetParent(transform);
        }
        // Obstaculo 2 (Alto) 30% [1.0 a 0.7] //* TRONCO
        if (probabilidad >= 0.7){
            Transform puntoAlto = puntoGen;
            puntoAlto.position = new Vector3(puntoGen.position.x, puntoGen.position.y + 1f,puntoGen.position.z);
            GameObject obstaculo = Instantiate(obstaculo2Prefab, puntoAlto.position, obstaculo2Prefab.transform.rotation, obstaculo2Prefab.transform);
            obstaculo.transform.SetParent(transform);
        }
        // Obstaculo 4 (Rebote) 10% [0.1 a 0.0] //* SETA
        if (probabilidad <= 0.03f && probabilidad >= 0.0f){
             GameObject obstaculo = Instantiate(obstaculo4Prefab, puntoGen.position, obstaculo4Prefab.transform.rotation, obstaculo4Prefab.transform);
             obstaculo.transform.SetParent(transform);
             GenerarMonedasEnParabola(new Vector3(puntoGen.position.x, puntoGen.position.y + 3f, puntoGen.position.z + 1f));
        }
        
    }
    void GenerarMoneda(){

        //* Escoger un punto random (1,2,3) para generar la Moneda

        // Numero random de posicion en carril (1,2,3)
        monedaGenIndex = Random.Range(2,5);

        // La posicion debe ser distinta a los obstaculos
        while (monedaGenIndex == obstaculoGenIndex){
            monedaGenIndex = Random.Range(2,5);
        }

        // Guarda la posicion 1,2 O 3 en "puntoGen"
        Transform puntoGen = transform.GetChild(monedaGenIndex).transform;

        // Probabilidad para generar (opcinal con un if (probabildiad < 0.3) por ejemplo)
        //float probabilidad = Random.Range(0f,1f);

        // Generar Moneda
        Instantiate(monedaPrefab, puntoGen.position, monedaPrefab.transform.rotation, monedaPrefab.transform);
        //moneda.transform.SetParent(transform);
    }

    void GenerarEnemigo(){

        // Numero random de posicion en carril (1,2,3)
        enemigoGenIndex = Random.Range(2,5);

        while (enemigoGenIndex == obstaculoGenIndex || enemigoGenIndex == monedaGenIndex){
            enemigoGenIndex = Random.Range(2,5);
        }

        // Guarda la posicion 1, 2 o 3 en "puntoGen"
        Transform puntoGen = transform.GetChild(enemigoGenIndex).transform;

        Transform puntoAlto = puntoGen;
        puntoAlto.position = new Vector3(puntoGen.position.x, puntoGen.position.y, puntoGen.position.z);


        // Probabilidad para generar (opcional con un if (probabildiad < 0.3) por ejemplo)
        float probabilidad = Random.Range(0f,1f);

        // Generar Enemigo 15% [0.1 a 0.0]
        if(probabilidad <= 0.15) {
            GameObject enemigo = Instantiate(Enemigo1Prefab,puntoAlto.position,Enemigo1Prefab.transform.rotation,Enemigo1Prefab.transform);
            enemigo.transform.SetParent(transform);
            enemigoGenerado = true;
        }

        //* Generar Obstaculo si no se genera enemigo (20%) [0.3 a 0.1)
        if (probabilidad <= 0.3 && probabilidad > 0.1 ){
            // Instantiate(obstaculo1Prefab,puntoGen.position,obstaculo1Prefab.transform.rotation,obstaculo1Prefab.transform);

            puntoAlto.position = new Vector3(puntoGen.position.x, puntoGen.position.y, puntoGen.position.z);

            GameObject enemigo = Instantiate(obstaculo1Prefab, puntoAlto.position, obstaculo1Prefab.transform.rotation, obstaculo1Prefab.transform);
            enemigo.transform.SetParent(transform);
        }
    }
    
    void GenerarPoder()
    {
        // Si se genera un Enemigo, no se puede generar Poder

        if (enemigoGenerado == true){
            return;
        }

        // Numero random de posicion en carril (1,2,3)
        poderGenIndex = Random.Range(2, 5);

        // La posicion debe ser distinta a los obstaculos
        //TODO: No probar dando todos los index se crashea
        while (poderGenIndex == obstaculoGenIndex || poderGenIndex == monedaGenIndex)
        {
            poderGenIndex = Random.Range(2, 5);
        }

        // Guarda la posicion 1,2 O 3 en "puntoGen"
        Transform puntoGen = transform.GetChild(poderGenIndex).transform;

        // Probabilidad para generar (opcinal con un if (probabildiad < 0.3) por ejemplo)
        float probabilidad = Random.Range(0f, 1f);

        // Generar Poder 1 (MORADO)
        if (probabilidad <= 0.05f)
        {
            GameObject poder = Instantiate(poder1Prefab, puntoGen.position, poder1Prefab.transform.rotation, poder1Prefab.transform);
            poder.transform.SetParent(transform);
        }

        // Generar Poder 2 (AZUL)
        if (probabilidad > 0.55f && probabilidad <= 0.6)
        {
            GameObject poder = Instantiate(poder2Prefab, puntoGen.position, poder2Prefab.transform.rotation, poder2Prefab.transform);
            poder.transform.SetParent(transform);
        }


    }

    void GenerarMonedasEnParabola(Vector3 posicionInicial)
    {
        int cantidadMonedas = 6;
        float alturaMaxima = 16f;
        float distanciaEntreMonedas = 6f;

        for (int i = 0; i < cantidadMonedas; i++)
        {
            float t = (float)i / (cantidadMonedas - 1);
            float altura = 4 * alturaMaxima * (t - t * t);
            Vector3 posicion = new Vector3(posicionInicial.x, posicionInicial.y + altura, posicionInicial.z + i * distanciaEntreMonedas);

            //Instantiate(monedaPrefab, posicion, Quaternion.identity, transform);
            Instantiate(monedaPrefab, posicion, monedaPrefab.transform.rotation, monedaPrefab.transform);
        }
    }
    
}

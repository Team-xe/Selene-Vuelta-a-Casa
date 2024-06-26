using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
** Script para el Salto, Movimiento horizontal, Avance automatico y Muerte del Jugador
**/
public class JugadorMovimiento : MonoBehaviour
{
    public GameObject fuegoFatuo;
    public Animator animator;

    //* Variables bool
    bool vivo = true;
    bool enSuelo = true;
    public bool invulnerable = false;
    private bool trampolinEnProgreso = false;


    //* Variables de movimiento adelante y salto

    public Rigidbody rb; // Cuerpo sometido a fisicas
    public float velocidad = 15f; // Que tan rapido avanza el Jugador
    public float velocidadHorizontal = 20f;
    public float fuerzaSalto = 30f; // fuerza con la que salta el jugador

    public float alturaMaxima = 5.5f; // Techo o limite maximo de altura
    public float umbralAltura = 5.0f; // Altura desde la que se comienza a reducir la velocidad

    //* Variables para Sistema Touch
    private float distanciaMin = 50f;
    private Vector2 puntoInicio;
    private Vector2 puntoFinal;


    //* Variables de movimiento por Carriles

    public Transform carrilesPadre; // GameObject Padre donde estan los carriles como Hijos
    public Transform[] carrilesPos; // Lista de posiciones o transform de cada carril
    public Transform carrilPosActual; // Transform o Posicion del Carril Actual en el que esta el Jugador (buscado en carrilesPos[])
    public int carrilIndexActual = 1; // index de Carriles 0, 1, 2

    //* Variables para Referenciar Scripts
    public Puntaje Ptsvivo;
    private ContadorMonedas contadorMonedas;
    public GameObject menuDerrota;
    public Poder1 poder1Morado;
    public Poder2 poder2Azul;

    public float tiempoPoderAzul = 7f;

    public float poder_comprado = 0f;


    void Start()
    {
        Time.timeScale = 1f;
        
        velocidad = 15f;
        Invoke("AumentarVelocidadInicial",5f);

        animator.SetBool("Correr",true);
        menuDerrota.SetActive(false);

        contadorMonedas = FindObjectOfType<ContadorMonedas>();

        // Asigno cada transform (posicion) que tengan los Hijos del Padre "carrilesPadre" en una posicion (carrilesPos[])
        carrilesPos = new Transform[carrilesPadre.childCount];

        for (int i = 0; i < carrilesPadre.childCount; i++){
            carrilesPos[i] = carrilesPadre.GetChild(i);
        }

        // El transform actual de carrilesPos[] es el de la posicion Index (parte en 1)
        carrilPosActual = carrilesPos[carrilIndexActual];

        poder_comprado = PlayerPrefs.GetInt("PoderComprado");

        if (poder_comprado == 1){
            MejorarPoderAzul();
        }

        
    }


    private void FixedUpdate(){
        if (!vivo) return; // Si no esta vivo detiene el metodo y no permite que se siga moviendo
        

        //* Movimiento Adelante Infinito y Horizontal
        // Vector que mueve al GameObject hacia adelante con una velocidad (en un espacio 3D)
        Vector3 avanzar = transform.forward * velocidad * Time.fixedDeltaTime;

        // Mueve la posicion del GameObject la distancia de los 2 Vectores creados anteriormente (usando el RigidBody)
        rb.MovePosition(rb.position + avanzar); 

        // Cambia el Carril al que debe moverse por el que indique el Index (cambiado por A o D)
        carrilPosActual = carrilesPos[carrilIndexActual];
        // Modifica la posicion a una donde en X //Posicion inicial, Posicion objetivo, delta X (velocidad)
        transform.position = Vector3.MoveTowards(transform.position, carrilPosActual.position, velocidadHorizontal*Time.deltaTime);

        //* Controlar la velocidad de subida
        // dentro del umbral
        if (rb.position.y > umbralAltura && rb.position.y < alturaMaxima){
            float reduccion = Mathf.Lerp(1f, 0.5f, (rb.position.y - umbralAltura) / (alturaMaxima - umbralAltura) );
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * reduccion, rb.velocity.z);
        }
        // despues de la altura Maxima
        else if (rb.position.y >= alturaMaxima){
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.position = new Vector3(rb.position.x, alturaMaxima, rb.position.z);
        }

    }

    public void SistemaTouch(){
        // Detecto el inicio del toque
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            // Guardo la posicion
            puntoInicio = Input.GetTouch(0).position;

        }
        //GetTouch(0) = 1 dedo

        // Detecto el final del toque
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
            // Guardo la posicion
            puntoFinal = Input.GetTouch(0).position;

            // saco dist entre 2 puntos
            float distanciaPuntos = Vector2.Distance(puntoInicio,puntoFinal);

            // Verifico si el usuario arrastra la distancia suficiente
            if (distanciaPuntos > distanciaMin){

                // calcular la direccion de desplazamiento del dedo
                Vector2 direccionDesplazamiento = puntoFinal - puntoInicio; //ej: 7-0

                // normalizar para ver donde se mueve (valores 1 al 0) 0,0  0,1  1,0  1,1
                direccionDesplazamiento.Normalize();
                

                MovimientoGeneral(direccionDesplazamiento);
            }
        }
    }

    private void MovimientoGeneral(Vector2 direccion){

        float deltaX = Mathf.Abs(direccion.x);
        float deltaY = Mathf.Abs(direccion.y);

        if (deltaX > deltaY){
            if (direccion.x > 0){
                MoverDerecha();
            }
            else if (direccion.x < 0){
                MoverIzquierda();
            }
        }

        else {
            if (direccion.y > 0){
                Saltar();
            }
            else if (direccion.y < 0){
                Bajar();
            }
        }
    }

    private void Update()
    {
        //* Inputs en Dispositivos Moviles
        SistemaTouch();

        // Movimientos horizontales PC
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoverIzquierda();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoverDerecha();
        }

        // Movimientos Verticales PC
        if (Input.GetKeyDown(KeyCode.W))
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Bajar();
        }

        // Morir si se cae
        if (transform.position.y < -2)
        {
            Morir();
        }

        // Invocar Poder 1 con la E (Gravedad - Morado)
        if (Input.GetKeyDown(KeyCode.E)){
            poder1Morado.ElevarEnemigos();
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            poder2Azul.HacerInvulnerableJugador();
        }
    }

    public void AumentarVelocidadInicial(){
        velocidad = 28f;
        velocidadHorizontal = 33f;
        fuerzaSalto = 44f;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //Reset de salto
    }


    public void MejorarPoderAzul(){
        tiempoPoderAzul = 12f; // antes era 7f, fue un +5f
    }
    /**
    ** Metodo para que el Jugador se mueva entre los 3 carriles hacia la izquierda o derecha
    **/
    public void MoverIzquierda(){
        if (carrilIndexActual > 0){
            carrilIndexActual--;
        }
    }

    public void MoverDerecha(){
        if (carrilIndexActual < carrilesPos.Length-1){
            carrilIndexActual++;
        }
    }


    /**
    ** Metodo para que el Jugador Salte hacia arriba usando una Fuerza
    **/
    public void Saltar(){
        if (rb != null && enSuelo == true){
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //Reset de salto
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse); // Aplica una fuerza Vertical hacia arriba para simular un Salto (en un espacio 3D)
            enSuelo = false;

            animator.SetBool("Saltar",true);
            animator.SetBool("Correr",false);
            Debug.Log("Saltaste");
            AudioManager.instance.ReproducirEfectos("Salto");
        }
    }

    public void Bajar(){
        if (rb != null && enSuelo == false){
            animator.SetBool("Bajar",true);
            animator.SetBool("Saltar",false);

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //Reset de salto
            rb.AddForce(Vector3.down * (fuerzaSalto-2f), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene la etiqueta "Suelo"
        if (collision.gameObject.CompareTag("Suelo")){
            enSuelo = true;
            animator.SetBool("Saltar",false);
            animator.SetBool("Correr",true);
            animator.SetBool("Bajar",false);
            alturaMaxima = 5.5f;
            
        }
        /*
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            Morir();
        }
        */

    }

    public void trampolinSalto()
    {
        if (!trampolinEnProgreso)
        {
            trampolinEnProgreso = true;
            alturaMaxima = 140f;
            umbralAltura = 12f;
            
            float dobleFuerza = fuerzaSalto * 1.5f;
            rb.AddForce(Vector3.up * dobleFuerza, ForceMode.Impulse);
            enSuelo = false;
            animator.SetBool("Saltar", true);
            animator.SetBool("Correr", false);
            AudioManager.instance.ReproducirEfectos("Seta");
            Invoke("IniciarAumentoVelocidad", 1f);
        }
    }

    private void IniciarAumentoVelocidad()
    {
        StartCoroutine(AumentarVelocidadTemporalmente());
    }

    private IEnumerator AumentarVelocidadTemporalmente()
    {
        float velocidadHorizontalOriginal = velocidadHorizontal;
        float alturaMaximaOriginal = alturaMaxima;
        float umbralAlturaOriginal = umbralAltura;
        float fuerzaSaltoOriginal = fuerzaSalto;
        velocidadHorizontal *= 1.25f;

        yield return new WaitForSeconds(0.8f);
        alturaMaxima = alturaMaximaOriginal;
        umbralAltura = umbralAlturaOriginal;
        fuerzaSalto = fuerzaSaltoOriginal;
        enSuelo = true;
        velocidadHorizontal = velocidadHorizontalOriginal;
        trampolinEnProgreso = false;
    }

    public void ActivarInvulnerabilidad()
    {
        invulnerable = true;
        fuegoFatuo.SetActive(true);

        Invoke("DesactivarInvulnerabilidad", tiempoPoderAzul);
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(tiempoPoderAzul);
        DesactivarInvulnerabilidad();
    }
    private void DesactivarInvulnerabilidad()
    {
        invulnerable = false;
        fuegoFatuo.SetActive(false);
    }

    /**
    ** Metodo para matar al Jugador reiniciando la escena actual
    **/
    public void Morir(){
        AudioManager.instance.ReproducirEfectos("Muerte");
        vivo = false;
        menuDerrota.SetActive(true);
        Ptsvivo.JugadorMuerto();
        contadorMonedas.ActualizarTexto();
        //gameObject.SetActive(false);
        Time.timeScale = 0f; // Detiene la partida
    }

    public bool EsInvulnerable()
    {
        return invulnerable;
    }

    public void DestruirEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        AudioManager.instance.ReproducirEfectos("Poder2");
        AudioManager.instance.ReproducirEfectos("MuerteTodo");
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }
        DesactivarInvulnerabilidad();
    }

    //FALTA ASIGNAR LO DEL PST VIVO, para que se vuelvan a activar
    public void Revivir()
    {
        AudioManager.instance.ReproducirEfectos("Revivir1");
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        Ptsvivo.JugadorVivo();
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }

        vivo = true;
        gameObject.SetActive(true);
        menuDerrota.SetActive(false);
        Time.timeScale = 1f;
        rb.velocity = Vector3.zero;

        animator.SetBool("Correr", true);
        animator.SetBool("Saltar", false);
        animator.SetBool("Bajar", false);

    }
}


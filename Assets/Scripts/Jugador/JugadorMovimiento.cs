using System.Collections;
using System.Collections.Generic;
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
    private bool invulnerable = false;
    

    //* Variables de movimiento adelante y salto

    [SerializeField] Rigidbody rb; // Cuerpo sometido a fisicas
    public float velocidad = 15f; // Que tan rapido avanza el Jugador
    public float velocidadHorizontal = 20f;
    [SerializeField] float fuerzaSalto = 30f; // fuerza con la que salta el jugador


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
        fuerzaSalto = 41f;
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
            
        }
        /*
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            Morir();
        }
        */

    }

    public void ActivarInvulnerabilidad()
    {
        if (invulnerable)
        {
            StopCoroutine("DesactivarInvulnerabilidadCoroutine");
        }
        invulnerable = true;
        fuegoFatuo.SetActive(true);

        Invoke("DesactivarInvulnerabilidad", 5f);
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(5f);
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
        gameObject.SetActive(false);
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
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }
        DesactivarInvulnerabilidad();
    }
}


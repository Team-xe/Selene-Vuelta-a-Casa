using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador2 : MonoBehaviour
{
    public Animator animator;
    //* Variables bool
    bool vivo = true;
    bool enSuelo = true;
    //* Variable para contador puntaje
    public Puntaje Ptsvivo;
    private bool trampolinEnProgreso = false;

    //* Variables de movimiento adelante y salto

    [SerializeField] Rigidbody rb; // Cuerpo sometido a fisicas
    public float velocidad = 15f; // Que tan rapido avanza el Jugador
    public float velocidadHorizontal = 20f;
    [SerializeField] float fuerzaSalto = 37f; // fuerza con la que salta el jugador


    public float alturaMaxima = 5.5f; // Techo o limite maximo de altura
    public float umbralAltura = 5.0f;

    //* Variables para Sistema Touch
    private float distanciaMin = 50f;
    private Vector2 puntoInicio;
    private Vector2 puntoFinal;


    //* Variables de movimiento por Carriles

    public Transform carrilesPadre; // GameObject Padre donde estan los carriles como Hijos
    public Transform[] carrilesPos; // Lista de posiciones o transform de cada carril
    public Transform carrilPosActual; // Transform o Posicion del Carril Actual en el que esta el Jugador (buscado en carrilesPos[])
    public int carrilIndexActual = 1; // index de Carriles 0, 1, 2


    //VEAMOS SI LOS PONGO
    private ContadorMonedas contadorMonedas;
    public GameObject menuDerrota;


    void Start()
    {
        Time.timeScale = 1f;
        
        velocidad = 15f;
        Invoke("AumentarVelocidadInicial", 0.5f);

        animator.SetBool("Correr", true);
        menuDerrota.SetActive(false);

        contadorMonedas = FindObjectOfType<ContadorMonedas>();

        // Asigno cada transform (posicion) que tengan los Hijos del Padre "carrilesPadre" en una posicion (carrilesPos[])
        carrilesPos = new Transform[carrilesPadre.childCount];

        for (int i = 0; i < carrilesPadre.childCount; i++)
        {
            carrilesPos[i] = carrilesPadre.GetChild(i);
        }

        // El transform actual de carrilesPos[] es el de la posicion Index (parte en 1)
        carrilPosActual = carrilesPos[carrilIndexActual];


    }


    private void FixedUpdate()
    {
        if (!vivo) return; // Si no esta vivo detiene el metodo y no permite que se siga moviendo


        //* Movimiento Adelante Infinito y Horizontal
        // Vector que mueve al GameObject hacia adelante con una velocidad (en un espacio 3D)
        Vector3 avanzar = transform.forward * velocidad * Time.fixedDeltaTime;

        // Mueve la posicion del GameObject la distancia de los 2 Vectores creados anteriormente (usando el RigidBody)
        rb.MovePosition(rb.position + avanzar);

        // Cambia el Carril al que debe moverse por el que indique el Index (cambiado por A o D)
        carrilPosActual = carrilesPos[carrilIndexActual];
        // Modifica la posicion a una donde en X //Posicion inicial, Posicion objetivo, delta X (velocidad)
        transform.position = Vector3.MoveTowards(transform.position, carrilPosActual.position, velocidadHorizontal * Time.deltaTime);

        //* Controlar la velocidad de subida
        // dentro del umbral
        if (rb.position.y > umbralAltura && rb.position.y < alturaMaxima)
        {
            float reduccion = Mathf.Lerp(1f, 0.5f, (rb.position.y - umbralAltura) / (alturaMaxima - umbralAltura));
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * reduccion, rb.velocity.z);
        }
        // despues de la altura Maxima
        else if (rb.position.y >= alturaMaxima)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.position = new Vector3(rb.position.x, alturaMaxima, rb.position.z);
        }
    }

    public void SistemaTouch()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.position.y >= Screen.height / 2)
                {
                    // Guardar la posici�n inicial del toque
                    if (touch.phase == TouchPhase.Began)
                    {
                        puntoInicio = touch.position;
                    }

                    // Guardar la posici�n final del toque y calcular la distancia
                    if (touch.phase == TouchPhase.Ended)
                    {
                        puntoFinal = touch.position;
                        float distanciaPuntos = Vector2.Distance(puntoInicio, puntoFinal);

                        // Verificar si el usuario arrastra la distancia suficiente
                        if (distanciaPuntos > distanciaMin)
                        {
                            // Calcular la direcci�n del desplazamiento del dedo
                            Vector2 direccionDesplazamiento = puntoFinal - puntoInicio;
                            direccionDesplazamiento.Normalize();

                            MovimientoGeneral(direccionDesplazamiento);
                        }
                        else
                        {
                            // Toque corto en la mitad superior de la pantalla
                            if (puntoInicio.x < Screen.width / 2)
                            {
                                // Izquierda de la pantalla
                                MoverIzquierda();
                            }
                            else
                            {
                                // Derecha de la pantalla
                                MoverDerecha();
                            }
                        }
                    }
                }
            }
        }
    }

    private void MovimientoGeneral(Vector2 direccion)
    {

        float deltaX = Mathf.Abs(direccion.x);
        float deltaY = Mathf.Abs(direccion.y);

        if (deltaX > deltaY)
        {
            if (direccion.x < 0)
            {
                MoverDerecha();
            }
            else if (direccion.x > 0)
            {
                MoverIzquierda();
            }
        }

        else
        {
            if (direccion.y < 0)
            {
                Saltar();
            }
            else if (direccion.y > 0)
            {
                Bajar();
            }
        }
    }

    private void Update()
    {
        if (transform.position.y < -2)
        {
            Morir();
        }
        SistemaTouch();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoverIzquierda();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoverDerecha();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Bajar();
        }
    }

    public void AumentarVelocidadInicial()
    {
        velocidad = 28f;
        velocidadHorizontal = 33f;
        fuerzaSalto = 44f;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //Reset de salto
    }

    /**
    ** Metodo para que el Jugador se mueva entre los 3 carriles hacia la izquierda o derecha
    **/
    public void MoverIzquierda()
    {
        if (carrilIndexActual > 0)
        {
            carrilIndexActual--;
        }
    }

    public void MoverDerecha()
    {
        if (carrilIndexActual < carrilesPos.Length - 1)
        {
            carrilIndexActual++;
        }
    }


    /**
    ** Metodo para que el Jugador Salte hacia arriba usando una Fuerza
    **/
    public void Saltar()
    {
        if (rb != null && enSuelo == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //Reset de salto

            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse); // Aplica una fuerza Vertical hacia arriba para simular un Salto (en un espacio 3D)
            
            enSuelo = false;

            animator.SetBool("Saltar", true);
            animator.SetBool("Correr", false);
            Debug.Log("Saltaste");
            AudioManager.instance.ReproducirEfectos("Salto");
        }
    }

    public void Bajar()
    {
        if (rb != null && enSuelo == false)
        {
            animator.SetBool("Bajar", true);
            animator.SetBool("Saltar", false);

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //Reset de salto

            rb.AddForce(Vector3.down * (fuerzaSalto - 2f), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene la etiqueta "Suelo"
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            animator.SetBool("Saltar", false);
            animator.SetBool("Correr", true);
            animator.SetBool("Bajar", false);
            alturaMaxima = 5.5f;

        }

    }

    /**
    ** Metodo para matar al Jugador reiniciando la escena actual
    **/
    public void Morir()
    {
        Debug.Log("Player is not invulnerable. Player dies.");
        AudioManager.instance.ReproducirEfectos("Muerte");
        vivo = false;
        menuDerrota.SetActive(true);
        Time.timeScale = 0f; // Detiene la partida

        //tsvivo.JugadorMuerto();
        //contadorMonedas.ActualizarTexto();
        gameObject.SetActive(false);

    }

    public void trampolinSalto()
    {
        if (!trampolinEnProgreso)
        {
            trampolinEnProgreso = true;
            alturaMaxima = 140f;
            umbralAltura = 12f;
            float dobleFuerza = fuerzaSalto * 2.55f;
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

        yield return new WaitForSeconds(1.2f);
        alturaMaxima = alturaMaximaOriginal;
        umbralAltura = umbralAlturaOriginal;
        fuerzaSalto = fuerzaSaltoOriginal;
        enSuelo = true;
        velocidadHorizontal = velocidadHorizontalOriginal;
        trampolinEnProgreso = false;
    }

}

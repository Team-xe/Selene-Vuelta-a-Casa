using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
** Script para el Salto, Movimiento horizontal, Avance automatico y Muerte del Jugador
**/
public class JugadorMovimiento : MonoBehaviour
{
    //* Variables bool
    bool vivo = true;
    bool enSuelo = true;
    

    //* Variables de movimiento adelante y salto

    [SerializeField] Rigidbody rb; // Cuerpo sometido a fisicas

    public float velocidad = 20; // Que tan rapido avanza el Jugador
    [SerializeField] float fuerzaSalto = 30f; // fuerza con la que salta el jugador


    //* Variables de movimiento por Carriles

    public Transform carrilesPadre; // GameObject Padre donde estan los carriles como Hijos
    public Transform[] carrilesPos; // Lista de posiciones o transform de cada carril

    public Transform carrilPosActual; // Transform o Posicion del Carril Actual en el que esta el Jugador (buscado en carrilesPos[])

    public int carrilIndexActual = 1; // index de Carriles 0, 1, 2
    public float velocidadHorizontal = 15f;


    void Start()
    {
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

    private void Update()
    {
        //* Movimiento Horizontal por Carriles

        if (Input.GetKeyDown(KeyCode.A)){

            if (carrilIndexActual > 0){
                carrilIndexActual--;
            }
        }

        if (Input.GetKeyDown(KeyCode.D)){
            if (carrilIndexActual < carrilesPos.Length-1){
                carrilIndexActual++;
            }
        }

        //* Mata al jugador cuando se cae del mapa (cuando esta en la altura y < -5)
        if (transform.position.y < -2){
            Morir();
        }

        //* Saltar con la W y solo 1 vez
        if (Input.GetKeyDown(KeyCode.W) && enSuelo == true){
            Debug.Log("Saltaste");
            enSuelo = false;
            Saltar();
        }

        //* Bajar rapido con la S
        if (Input.GetKeyDown(KeyCode.S) && enSuelo == false){
            Bajar();
        }
        
    }


    /**
    ** Metodo para que el Jugador Salte hacia arriba usando una Fuerza
    **/
    void Saltar(){
        if (rb != null){
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse); // Aplica una fuerza Vertical hacia arriba para simular un Salto (en un espacio 3D)
        }
    }

    void Bajar(){
        if (rb != null){
            rb.AddForce(Vector3.down * (fuerzaSalto-10f), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene la etiqueta "Suelo"
        if (collision.gameObject.CompareTag("Suelo")){
            enSuelo = true;
        }
    }


    /**
    ** Metodo para matar al Jugador reiniciando la escena actual
    **/
    public void Morir(){
        vivo = false;
        //Reinicia el juego
        Debug.Log("Has muerto");
        Invoke("Reiniciar",2);
    }


    /**
    * Metodo para reiniciar la escena actual
    **/
    void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

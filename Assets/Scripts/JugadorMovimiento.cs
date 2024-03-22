using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorMovimiento : MonoBehaviour
{

    bool vivo = true;
    bool enSuelo = true;

    public float velocidad = 7f; // Que tan rapido avanza el Jugador

    [SerializeField] Rigidbody rb; // Cuerpo sometido a fisicas


    [SerializeField] float horizontalInput; // toma valores segun las flechas de teclado o A,D (entre 1 y -1)
    [SerializeField] float horizontalMultiplicador = 2; // multiplicador del movimiento horizontal

    [SerializeField] float fuerzaSalto = 20f; // fuerza con la que salta el jugador
    [SerializeField] LayerMask sueloMask; // LayerMask para detectar suelos



    void Start()
    {
        
    }

    private void FixedUpdate(){
        if (!vivo) return; // Si no esta vivo detiene el metodo y no permite que se siga moviendo


        //* Movimiento Adelante Infinito y Horizontal
        Vector3 avanzar = transform.forward * velocidad * Time.fixedDeltaTime; // Vector que mueve al GameObject hacia adelante con una velocidad (en un espacio 3D)
        Vector3 horizontal = transform.right * horizontalInput * velocidad * Time.fixedDeltaTime * horizontalMultiplicador; // Vector que mueve al personaje hacia la derecha con una velocidad y se invierte a izquierda según los valores de Horizontal -1 y 1
        

        rb.MovePosition(rb.position + avanzar + horizontal); // Mueve la posicion del GameObject la distancia de los 2 Vectores creados anteriormente (usando el RigidBody)
    }
    
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Funcion para obtener valores -1 y 1 con W A S D y flechas

        //* Mata al jugador cuando se cae del mapa (cuando esta en la altura y < -5)
        if (transform.position.y < -5){
            Morir();
        }

        //* Saltar con la E y solo 1 vez
        if (Input.GetKeyDown(KeyCode.E) && enSuelo == true){
            enSuelo = false;
            Saltar();
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
        Invoke("Reiniciar",2);
    }

    /**
    * Metodo para reiniciar la escena actual
    **/
    void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

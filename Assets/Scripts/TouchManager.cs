using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // Globalizamos la variable touch
    private Touch touch;

    // Booleano para detectar el touch en pantalla
    private bool isTouching;

    private bool moverse = false;

    public JugadorMovimiento jugadorMovimiento;

    void Start()
    {
        
    }

    // Ir detectando los Touch continuamente
    void Update()
    {
        //MouseInputDebug();
        //TouchInputDebug();

        
    }

    void FixedUpdate(){
        TouchPhases();
    }

    public void TouchPhases(){

        // Validar si se esta tocando la pantalla
        if (Input.touchCount > 0){

            //Variable para almacenar el Tipo de Touch
            touch = Input.GetTouch(0);


            //* Tipos de Touch

            // Switch para validar las fases de Touch ( ver que fase es )
            switch(touch.phase){
                case TouchPhase.Began:
                    print("Se ejecuta cuando toco la pantalla");
                    isTouching = true;
                    break;
                case TouchPhase.Canceled:
                    print("Se cancela el touch");
                    isTouching = false;
                    break;
                case TouchPhase.Stationary:
                    print("Mantengo en la misma posicion un dedo");
                    isTouching = true;
                    break;
                case TouchPhase.Moved:
                    print("Muevo el dedo");
                    isTouching = true;

                    // Calculo desplazamiento horizontal del dedo
                    float desplazamientoX = touch.deltaPosition.x;

                    float desplazamientoY = touch.deltaPosition.y;

                    // Distancia Umbral de movimiento horizontal para detectarlo

                    float distanciaX = 10f;

                    float distanciaY = 10f;
            
                    // Si desplazamiento es mayor que distancia, determina la direccion del movimiento
                    if (Mathf.Abs(desplazamientoX) > distanciaX && moverse == true && Mathf.Abs(desplazamientoX) > Mathf.Abs(desplazamientoY)){

                        // Si desplazamiento es hacia la izquierda (negativo)
                        if (desplazamientoX < 0){

                            jugadorMovimiento.MoverIzquierda();
                        }

                        else if (desplazamientoX > 0){
                            jugadorMovimiento.MoverDerecha();
                        }

                    }

                    if (Mathf.Abs(desplazamientoY) > distanciaY && moverse == true && Mathf.Abs(desplazamientoY) > Mathf.Abs(desplazamientoX)){
                        if (desplazamientoY > 0){
                            jugadorMovimiento.Saltar();
                        }

                        else if (desplazamientoY < 0){
                            jugadorMovimiento.Bajar();
                        }
                    }
                    
                    moverse = false;

                    break;
                case TouchPhase.Ended:
                    print("Dejo de presionar la pantalla");
                    isTouching = false;
                    moverse = true;
                    break;
            }
        }
    }


    /*
    // Para cambiar a Touch y no Mouse
    public void MouseInputDebug() {
        // Si presiono el boton del mouse izquierdo ocurre algo
        if (Input.GetKey(KeyCode.Mouse0)){

            // Creamos un Raycast desde donde se presiona el mouse en la camara
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Este rayo debe considerar la Camara y el Punto

            // Para detectar la colision necesitamos RaycastHit (tipo de dato que detecta colision)
            // Permite detectar colisiones
            RaycastHit hit;

            // El tamanio del Rayo importa en el desempenio de la app, mientras mas chico mejor

            float rayDistance = 100f;

            // Dibujamos en la escena el rayo programado
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

            // Condicional para validar si se produce un choque
            if (Physics.Raycast(ray, out hit, rayDistance)){

                // Detecto si choco con un objeto que tenga un collider
                if (hit.collider != null){
                    print("Estoy chocando con" + hit.collider.gameObject.name);
                }

                // Para no tener problemas con detectar cosas que no quiero sin querer pongo condiciones

                if (hit.collider.gameObject.CompareTag("Jugador")){
                    Destroy(hit.collider.gameObject);
                }
                
                // podria hacer lo mismo pero por nombre
                if (hit.collider.gameObject.name == "Jugador"){
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    */


    /*
    public void TouchInputDebug() {


        // Vector para almacenar la posicion del Touch
        Vector3 touchposition = touch.position;

        // Si presiono el boton del mouse izquierdo ocurre algo
        if (isTouching){

            // Creamos un Raycast desde donde se presiona el mouse en la camara
            Ray ray = Camera.main.ScreenPointToRay(touchposition); // Este rayo debe considerar la Camara y el Punto

            // Para detectar la colision necesitamos RaycastHit (tipo de dato que detecta colision)
            // Permite detectar colisiones
            RaycastHit hit;

            // El tamanio del Rayo importa en el desempenio de la app, mientras mas chico mejor

            float rayDistance = 100f;

            // Dibujamos en la escena el rayo programado
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

            // Condicional para validar si se produce un choque
            if (Physics.Raycast(ray, out hit, rayDistance)){

                // Detecto si choco con un objeto que tenga un collider
                if (hit.collider != null){
                    print("Estoy chocando con" + hit.collider.gameObject.name);
                }

                // Para no tener problemas con detectar cosas que no quiero sin querer pongo condiciones

                if (hit.collider.gameObject.CompareTag("Jugador")){
                    Destroy(hit.collider.gameObject);
                }
                
                // podria hacer lo mismo pero por nombre
                if (hit.collider.gameObject.name == "Jugador"){
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    */
}

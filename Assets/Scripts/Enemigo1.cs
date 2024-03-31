using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Quaternion angulo;
    public float grado;
    JugadorMovimiento jugadorMovimiento;

    public float velocidad;
    public float tiempoDeEspera = 0.5f;
    private int direccion = 1; 
    private float tiempoPasado = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>();
        
    }
    
    public void Movimiento()
    {
        cronometro += 1 * Time.deltaTime;
        //Cronometro
        if(cronometro >= 4) {
            //Sacamos un nuemro random para obtener una acciom cada 4 ticks
            rutina = Random.Range(0,2);
            cronometro = 0;
            //Reiniciamos el cronometro para obtener una nueva accion
        }
        switch (rutina) 
        {
            case 0:
                //Se queda parado
                break;
            case 1:
                grado = Random.Range(0,180);
                //PROVAR aWSA 
                angulo = Quaternion.Euler(0,grado,0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward* 1 * Time.deltaTime);
                break;
        }
    }
    
    



    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Jugador"){
            // Matar al jugador
            jugadorMovimiento.Morir();
        }
    }

    void FixedUpdate()
    {

        transform.Translate(Vector3.right * velocidad * Time.fixedDeltaTime * direccion);

        //raycast para ver paredes no funciona solo con las paredes de la izquierda por alguna raozn
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right * direccion, out hit, 1f))
        {
            if (!hit.collider.CompareTag("Suelo"))
            {
                CambiarDireccion();
            }
        }
    }

    void CambiarDireccion()
    {
        //tampoco funciona
        direccion *= -1;
        tiempoPasado = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // tampoco funciona por que no funciona la fucino
        tiempoPasado += Time.deltaTime;
        if (tiempoPasado >= tiempoDeEspera)
        {
            CambiarDireccion();
        }
    }
}

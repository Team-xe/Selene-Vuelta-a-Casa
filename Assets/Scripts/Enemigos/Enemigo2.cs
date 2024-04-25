using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public float tiempomin = 1f; 
    private float tiempomax = 5f;
    private float tiempoSalto;
    private JugadorMovimiento jugadorMovimiento;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>();
        rb = GetComponent<Rigidbody>();
        calcularTiempo();
    }
    
    public void Salto()
    {
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Jugador"){
            // Matar al jugador
            jugadorMovimiento.Morir();
        }
    }

    private void calcularTiempo()
    {
        tiempoSalto = Time.time + Random.Range(tiempomin, tiempomax);
    }


    // Update is called once per frame
    void Update()
    {
    
        if (Time.time >= tiempoSalto)
        {
            Salto();
            calcularTiempo();
        }
    }
}

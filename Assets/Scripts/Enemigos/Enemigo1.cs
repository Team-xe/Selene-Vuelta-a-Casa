using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public float tiemposaltar = 3f; 
    private float tiempo = 0f;
    private JugadorMovimiento jugadorMovimiento;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        jugadorMovimiento = GameObject.FindObjectOfType<JugadorMovimiento>();
        rb = GetComponent<Rigidbody>();
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


    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
    
        if (tiempo >= tiemposaltar)
        {
            Salto();
            tiempo = 0f;
        }
    }
}

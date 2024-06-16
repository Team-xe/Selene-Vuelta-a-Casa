using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarVelocidad : MonoBehaviour
{
    public JugadorMovimiento jugadorMovimiento;
    public Carriles carriles;

    public float intervaloMin = 5f;
    public float intervaloMax = 10f;
    public float incrementoVelocidad = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AumentarVelocidadPeriodicamente());
    }

    IEnumerator AumentarVelocidadPeriodicamente()
    {
        while (true)
        {
   
            float tiempoEspera = Random.Range(intervaloMin, intervaloMax);
            yield return new WaitForSeconds(tiempoEspera);

            jugadorMovimiento.velocidad += incrementoVelocidad;
            jugadorMovimiento.velocidadHorizontal += incrementoVelocidad;
            carriles.velocidad += incrementoVelocidad;

        }
    }
}

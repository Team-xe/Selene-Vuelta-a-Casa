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
    public float tiempoSalto = 30f;
    public float aumentoFuerzaSalto = 1.06f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AumentarVelocidadPeriodicamente());
        StartCoroutine(AumentarFuerzaSaltoPeriodicamente());
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

    IEnumerator AumentarFuerzaSaltoPeriodicamente()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoSalto);
            jugadorMovimiento.fuerzaSalto *= aumentoFuerzaSalto;
        }
    }
}

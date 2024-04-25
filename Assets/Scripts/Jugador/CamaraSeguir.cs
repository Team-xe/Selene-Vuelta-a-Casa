using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    public Transform jugador;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jugador.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = jugador.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }

    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 nuevaPos = transform.position;
        nuevaPos.y = 1f;
        transform.position = nuevaPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

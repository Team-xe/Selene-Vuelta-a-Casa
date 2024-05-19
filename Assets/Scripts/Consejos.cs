using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consejos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        Invoke("DesactivarConsejos",3f);
    }

    public void DesactivarConsejos(){
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    
   public float tiempoCambiar;
   public string nombreEscena; 
    private void Update()
    {
       tiempoCambiar -= Time.deltaTime;
       if(tiempoCambiar <= 0) {
        SceneManager.LoadScene(nombreEscena);
       } 
    }
}

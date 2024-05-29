using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MenuTienda : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    int cantmonedas = 0;


    // Start is called before the first frame update
    void Start()
    {
        cantmonedas = PlayerPrefs.GetInt("TotalMonedaKey");
        textMesh.text = " "+ cantmonedas.ToString();
    }

}

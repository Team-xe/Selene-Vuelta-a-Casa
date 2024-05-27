using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MenuTienda : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    private GuardadoManager cargarMoneda;
    int cantmonedas = 0;


    // Start is called before the first frame update
    void Start()
    {
        cantmonedas = cargarMoneda.GetTotalCoins();
        textMesh.text = " " + cantmonedas.ToString("0");
    }

}

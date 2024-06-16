using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public PortalManager portalManager;

    void Start(){
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Jugador")){
            AudioManager.instance.ReproducirEfectos("Portal");
            print("PORTAL ACTIVADO");
            portalManager.CambiarMaterial(0);
            print("MATERIAL CAMBIADO");
        }
    }
}

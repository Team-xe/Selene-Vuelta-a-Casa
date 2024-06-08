using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Audio[] menuAudios, efectosAudios;
    public AudioSource menuSource, efectosSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReproducirMenu(string nombre)
    {
        Audio s = Array.Find(menuAudios, x => x.nombre == nombre);
        if (s == null)
        {
            Debug.Log("No se encontro el nombre de el audio");
        }
        else
        {
            menuSource.clip = s.clip;
            menuSource.Play();
        }
    }

    public void ReproducirEfectos(string nombre)
    {
        Audio s = Array.Find(efectosAudios, x => x.nombre == nombre);
        if (s == null)
        {
            Debug.Log("No se encontro el nombre de el audio");
        }
        else
        {
            efectosSource.PlayOneShot(s.clip);
        }
    }

    


    public void CambiarVolumenMenu(float volume)
    {
        menuSource.volume = volume;
    }

    public void CambiarVolumenEfectos(float volume)
    {
        efectosSource.volume = volume;
    }

}

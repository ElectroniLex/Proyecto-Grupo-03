using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public ListaPersonajes listas_Personajes;
    
   


    private int contadorDePersonajes;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("contadorDePersonajes"))
        {
            contadorDePersonajes = 0;
        }
        else
        {
            Cargar();
        }
        InvocarPersonaje(contadorDePersonajes);
    }

    private void InvocarPersonaje(int contadorDePersonajes)
    {
        Ficha personaje = listas_Personajes.obtenerPersonaje(contadorDePersonajes);
        Instantiate(personaje.objeto_jugador);
        //Instantiate(personaje.Camara_Prefab);
    }

    
    public void Cargar()
    {
        contadorDePersonajes = PlayerPrefs.GetInt("contadorDePersonajes");
    }

}

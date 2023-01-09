using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ListaPersonajes : ScriptableObject
{
    public Ficha[] personaje;

    public int contadorDePersonajes
    {
        get
        {
            return personaje.Length;
        }
    }
    public Ficha obtenerPersonaje(int index)
    {
        return personaje[index];
        
    }



}
    
    

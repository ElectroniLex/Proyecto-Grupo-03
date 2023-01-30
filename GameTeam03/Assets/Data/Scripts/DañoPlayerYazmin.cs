using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoPlayerYazmin : MonoBehaviour
{
    public int DañoPlayer;
    public GameObject EnemigoLagarto;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            EnemigoLagarto.GetComponent<VidaEnemigoLagarto>().vidaEnemigo -= DañoPlayer;
        }

        if (other.tag == ("Enemigo"))
        {
            Debug.Log("Esto es un enemigo");
        }
    }
}

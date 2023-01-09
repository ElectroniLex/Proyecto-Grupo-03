using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatoEnemigo : MonoBehaviour
{
    public int damage;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            player.GetComponent<datosJugador>().vidaPlayer -= damage;
        }

        if (other.tag == ("Enemigo"))
        {
            Debug.Log("Esto es un enemigo");
        }
    }
}

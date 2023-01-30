using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DatoEnemigo : MonoBehaviour
{
    public int VidaEnemigo;
    public GameObject player;
    //public Slider UIVida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            player.GetComponent<PlayerYazmin>().vidaPlayer -= VidaEnemigo;
        }

        if (other.tag == ("Enemigo"))
        {
            Debug.Log("Esto es un enemigo");
        }
    }
}

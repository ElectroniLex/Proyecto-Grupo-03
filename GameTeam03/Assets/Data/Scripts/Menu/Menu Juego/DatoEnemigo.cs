using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DatoEnemigo : MonoBehaviour
{
    public int DañoEnemigo;
    public GameObject player;
    //public Slider UIVida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            player.GetComponent<PlayerYazmin>().vidaPlayer -= DañoEnemigo;
        }

        if (other.tag == ("Enemigo"))
        {
            Debug.Log("Esto es un enemigo");
        }
    }
}

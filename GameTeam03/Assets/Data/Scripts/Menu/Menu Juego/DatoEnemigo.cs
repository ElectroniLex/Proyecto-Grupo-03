using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DatoEnemigo : MonoBehaviour
{
    public int DañoPlayerAlEnemigo;
    public GameObject player;
    //public Slider UIVida;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("Enemigo Recibe daño");


            player.GetComponent<PlayerYazmin>().vidaPlayer -= DañoPlayerAlEnemigo;
        }

       
    }
}

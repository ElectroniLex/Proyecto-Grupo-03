using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Da�oPlayerYazmin : MonoBehaviour
{
    public int Da�oPlayer;
    public GameObject EnemigoLagarto;
    public GameObject EnemigoMagoAzul;
    public GameObject EnemigoMagoVerde;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            EnemigoLagarto.GetComponent<VidaEnemigoLagartoGris>().vidaEnemigoLagarto -= Da�oPlayer;
            
        }

        if (other.tag == ("Enemigo"))
        {
            Debug.Log("Esto es un enemigo");
        }
    }
}

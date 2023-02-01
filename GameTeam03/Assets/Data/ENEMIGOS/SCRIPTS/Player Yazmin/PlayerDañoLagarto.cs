using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDañoLagarto : MonoBehaviour
{
    public int DañoAEnemigoMagoAzul;
    public GameObject EnemigoMagoAzul;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemigoMagoAzul.GetComponent<VidaEnemigoLagartoGris>().vidaEnemigoLagarto -= DañoAEnemigoMagoAzul;
            Debug.Log("Esto es un enemigo Lagarto");
        }

       
    }
}

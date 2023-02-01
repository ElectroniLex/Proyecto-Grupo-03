using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDañoMagoAzul : MonoBehaviour
{
    public int DañoAEnemigoMagoAzul;
    public GameObject EnemigoMagoAzul;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemigoMagoAzul.GetComponent<VidaEnemigoMagoAzul>().vidaEnemigoMagoVerde -= DañoAEnemigoMagoAzul;
            Debug.Log("Esto es un enemigo Mago Azul");
        }

       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDañoMagoVerde : MonoBehaviour
{
    public int DañoAEnemigoMagoVerde;
    public GameObject EnemigoMagoVerde;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemigoMagoVerde.GetComponent<VidaEnemigoMagoVerde>().vidaEnemigoMagoVerde -= DañoAEnemigoMagoVerde;
            Debug.Log("Esto es un enemigo Mago Azul");
        }

       
    }
}

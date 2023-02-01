using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigoLagartoGris : MonoBehaviour
{
   
    public int vidaEnemigoLagarto;

    public Slider sliderVidaMagoVerde;
    public GameObject DMagoVerde;
    void Update()
    {

        sliderVidaMagoVerde.GetComponent<Slider>().value = vidaEnemigoLagarto;

        if (vidaEnemigoLagarto <= 0)
        {
            Debug.Log("Enemigo derrotado");
            DMagoVerde.SetActive(false);
        }
    }
}

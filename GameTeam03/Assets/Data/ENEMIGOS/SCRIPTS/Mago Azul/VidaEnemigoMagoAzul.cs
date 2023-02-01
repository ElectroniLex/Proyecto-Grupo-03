using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigoMagoAzul : MonoBehaviour
{
   
    public int vidaEnemigoMagoVerde;

    public Slider sliderVidaMagoAzul;
    public GameObject DMagoAzul;
    void Update()
    {

        sliderVidaMagoAzul.GetComponent<Slider>().value = vidaEnemigoMagoVerde;

        if (vidaEnemigoMagoVerde <= 0)
        {
            Debug.Log("Enemigo derrotado");
            DMagoAzul.SetActive(false);
        }
    }
}

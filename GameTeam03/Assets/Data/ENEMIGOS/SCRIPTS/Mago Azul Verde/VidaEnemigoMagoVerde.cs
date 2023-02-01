using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaEnemigoMagoVerde : MonoBehaviour
{
   
    public int vidaEnemigoMagoVerde;

    public Slider sliderVidaMagoVerde;
    public GameObject DMagoVerde;
    void Update()
    {

        sliderVidaMagoVerde.GetComponent<Slider>().value = vidaEnemigoMagoVerde;

        if (vidaEnemigoMagoVerde <= 0)
        {
            Debug.Log("Enemigo derrotado");
            DMagoVerde.SetActive(false);
        }
    }
}

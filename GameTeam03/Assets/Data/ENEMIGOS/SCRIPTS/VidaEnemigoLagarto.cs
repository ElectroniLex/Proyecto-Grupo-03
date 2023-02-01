using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigoLagarto : MonoBehaviour
{
    //Vida de enemigo 
    public int vidaEnemigo;
    public Slider sliderVidaEnemigo;
    public Slider sliderVidaMago;
    public GameObject DerrotarLagarto;
    void Update()
    {
        sliderVidaEnemigo.GetComponent<Slider>().value = vidaEnemigo;
        sliderVidaMago.GetComponent<Slider>().value = vidaEnemigo;

        if (vidaEnemigo <= 0)
        {
            Debug.Log("Enemigo derrotar");
            DerrotarLagarto.SetActive(false);
        }
    }

    
}

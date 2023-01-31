using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigoLagarto : MonoBehaviour
{

    public int vidaEnemigo;
    public Slider sliderVidaEnemigo;
    public GameObject DerrotarLagarto;
    void Update()
    {
        sliderVidaEnemigo.GetComponent<Slider>().value = vidaEnemigo;


        if (vidaEnemigo <= 0)
        {
            DerrotarLagarto.SetActive(false);
        }
    }

    
}

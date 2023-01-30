using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigoLagarto : MonoBehaviour
{

    public int vidaEnemigo;
    public Slider sliderVidaEnemigo;
    void Update()
    {
        sliderVidaEnemigo.GetComponent<Slider>().value = vidaEnemigo;


        if (vidaEnemigo <= 0)
        {
            Debug.Log("Fin del Juego");
        }
    }

    
}

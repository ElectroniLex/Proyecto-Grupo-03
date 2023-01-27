using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuardarCargar : MonoBehaviour
{
    public int vidaPlayer;
    public Slider sliderVida;
 

    void Update()
    {
        sliderVida.GetComponent<Slider>().value = vidaPlayer;


        if (vidaPlayer <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}

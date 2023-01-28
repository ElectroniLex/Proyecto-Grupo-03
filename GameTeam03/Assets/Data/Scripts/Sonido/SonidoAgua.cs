using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAgua : MonoBehaviour
{
    public AudioSource aguaSonido;
    //public AudioSource bosqueAudio;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            aguaSonido.Play();
            //bosqueAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            aguaSonido.Stop();
            //bosqueAudio.Stop();
        }
    }


}

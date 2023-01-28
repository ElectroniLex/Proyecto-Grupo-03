using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPueblo : MonoBehaviour
{
    public AudioSource puebloAudio;
    //public AudioSource bosqueAudio;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            puebloAudio.Play();
            //bosqueAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            puebloAudio.Stop();
            //bosqueAudio.Stop();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAmbiente : MonoBehaviour
{
    public AudioSource AudioAgua;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player") AudioAgua.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            AudioAgua.Stop();
        }
    }

}

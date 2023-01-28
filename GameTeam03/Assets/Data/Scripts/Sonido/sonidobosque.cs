using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidobosque : MonoBehaviour
{
    public AudioSource SonidoBosque;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            SonidoBosque.Play();
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            SonidoBosque.Stop();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextShow : MonoBehaviour
{
    string frase = "asdasdsad";
    public TMP_Text texto;


    void Start()
    {
        StartCoroutine(Relog());

        
    }
    IEnumerator Relog()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
       
        
    }
}

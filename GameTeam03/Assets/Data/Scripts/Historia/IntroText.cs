using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class IntroText : MonoBehaviour
{
    public GameObject panel;
    public GameObject buttonIniciar;
    public GameObject textoPlay;

    public string[] SdialogoInicial;
    public string[] SdialogoPelea;
    public string[] SdialogoFinal;

    public TMP_Text txtDialogo;
    public bool isDialogActive;

    Coroutine auxCorutine;

    public void AbrirCajaDialogo(int valor)
    {
        if (isDialogActive)
        {
            CerrarDialogo();
            StartCoroutine(esperaSolapacionDialogo(valor));
            
        }
        else
        {
            isDialogActive = false;
            auxCorutine = StartCoroutine(mostrarDialogo(valor));
            
        }


    }

    IEnumerator mostrarDialogo(int valor, float time = 0.1f)
    {
        panel.SetActive(true);
        string[] dialogo; // Donde guardarekos el dialogo real
        if (valor == 0) dialogo = SdialogoInicial;
        else if (valor == 1) dialogo = SdialogoPelea;
        else dialogo = SdialogoFinal;

        int total = dialogo.Length;
        string res = "";
        isDialogActive = true;
        yield return null; // seguridad de 1 null
        for (int i = 0; i < total; i++)// recorremos todas las frases
        {
            res = "";
            if (isDialogActive)
            {
                for (int s = 0; s < dialogo[i].Length; s++)
                {
                    if (isDialogActive)
                    {
                        res = string.Concat(res, dialogo[i][s]);
                        txtDialogo.text = res;
                        yield return new WaitForSeconds(time);
                    }
                    else yield break;
                }
                yield return new WaitForSeconds(0.4f);
            }
            else yield break;

        }
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Cierramis Msorar");
        CerrarDialogo();

    }

    IEnumerator esperaSolapacionDialogo(int valor)
    {
        yield return new WaitForEndOfFrame();
        auxCorutine = StartCoroutine(mostrarDialogo(valor));
    }
    public void CerrarDialogo()
    {
        isDialogActive = false;
        if (auxCorutine != null)
        {
            Debug.Log("DETENER");
            StopCoroutine(auxCorutine);
            auxCorutine = null;
            
        }

        txtDialogo.text = "";
        buttonIniciar.SetActive(true);
        textoPlay.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AbrirCajaDialogo(0);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mundo");
        }
       
    }
}

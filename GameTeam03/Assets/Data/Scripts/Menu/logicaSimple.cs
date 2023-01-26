using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicaSimple : MonoBehaviour
{

    //public GameObject PanelCarga;
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salio del Juego");
    }
    public void cambiarEcenaMundo()
    {
        SceneManager.LoadScene("Introducion");
        Debug.Log("Cambio de ecenario  Introducion");
    }

    public void CerrarSesion()
    {
        SceneManager.LoadSceneAsync("Login");
    }

   /* public void Cargar()
    {
        PanelCarga.SetActive(true);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicaSimple : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salio del Juego");
    }
    public void cambiarEcenaMundo()
    {
        SceneManager.LoadScene("Juego");
        Debug.Log("Cambio de ecenario  JUEGO");
    }

    public void CerrarSesion()
    {
        SceneManager.LoadSceneAsync("Login");
    }
}

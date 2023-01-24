using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuIntroducion : MonoBehaviour
{
   public void Saltar ()
    {
        SceneManager.LoadScene("Juego");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaLogin : MonoBehaviour
{
    [SerializeField] private InputField m_email = null;
    [SerializeField] private InputField m_password = null;
    [SerializeField] private Text m_textError= null;

    public void Login()
    {

        if (m_email.text == "Wilfredo" &&  m_password.text == "Hola" )
        {
            SceneManager.LoadScene("Menu");
            return;
        }
        else
        {
            m_textError.text = "Verifique su correo y contraseña";
            return;
        }

   
    }

    
}

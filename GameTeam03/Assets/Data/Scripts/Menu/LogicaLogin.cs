using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaLogin : MonoBehaviour
{
    [SerializeField] private InputField m_email = null;
    [SerializeField] private InputField m_password= null;
    [SerializeField] private Text m_textError= null;

    public void Login()
    {

        if (m_email.text == "Wifredo@gmail.com" ||  m_password.text == "Hola" )
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            m_textError.text = "Verifique su correo y contraseña";
        }
    }
}

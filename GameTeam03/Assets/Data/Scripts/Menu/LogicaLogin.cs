using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicaLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField m_email = null;
    [SerializeField] private TMP_InputField m_password = null;
    [SerializeField] private TMP_Text m_textError= null;

    public void Login()
    {
        if (m_email.text =="" || m_password.text == "")
        {
            m_textError.text = "Rellenar todo los campos";
            return;
        }

        if (m_email.text == "Wilfredo@gmail.com" &&  m_password.text == "Hola" )
        {
            SceneManager.LoadScene("Menu");
            
        }
        else
        {
            m_textError.text = "Verifique su correo y contraseña";
            
        }
        return;
   
    }

    
}

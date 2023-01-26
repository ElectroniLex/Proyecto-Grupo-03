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

        if      (m_email.text == "Wilfredo@gmail.com" &&  m_password.text == "VRNR") SceneManager.LoadScene("Menu");
        else if (m_email.text == "Alex@gmail.com" && m_password.text == "KRFX")  SceneManager.LoadScene("Menu");
        else if (m_email.text == "Katherin@gmail.com" && m_password.text == "RVTG") SceneManager.LoadScene("Menu");
        else if (m_email.text == "Alejandro@gmail.com" && m_password.text == "VAIN") SceneManager.LoadScene("Menu");
        else if (m_email.text == "Yerick@gmail.com" && m_password.text == "MDGE") SceneManager.LoadScene("Menu");
        else if (m_email.text == "Henry@gmail.com" && m_password.text == "XUVT") SceneManager.LoadScene("Menu");
        else m_textError.text = "Verifique su correo y contraseña";
        
        return;
   
    }

    
}

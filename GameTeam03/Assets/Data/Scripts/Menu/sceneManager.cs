using UnityEngine;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{

    [SerializeField] private GameObject m_registerUI      = null;
    [SerializeField] private GameObject m_loginUI         = null;

    [SerializeField] private Text       m_Text       = null;

    [SerializeField] private InputField m_userNameInput   = null;
    [SerializeField] private InputField m_emailInput      = null;
    [SerializeField] private InputField m_password        = null;
    [SerializeField] private InputField m_reErterPassword = null;

    private NetworkManager m_networdManager = null;

    private void Awake()
    {
        m_networdManager = GameObject.FindObjectOfType<NetworkManager>();
    }


    public void SubmitRegister()
    {

        if (m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text== "" || m_reErterPassword.text == "")
        {
            m_Text.text = "Por favor llenar todod los campos";
            return;
        }


        if(m_password.text == m_reErterPassword.text)
        {
            m_Text.text = "Procesando...";

            m_networdManager.CreateUser(m_userNameInput.text, m_emailInput.text, m_password.text, delegate (Response response) 
            {
                m_Text.text = response.message;
            
            });
        }
        else
        {
            m_Text.text = "Contraseñas no son igual por favor verificar";
        }
    }


    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }

    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
    }
}

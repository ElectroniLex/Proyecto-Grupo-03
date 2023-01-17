using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoManager : MonoBehaviour
{
    public static DialogoManager instance { get; private set; }
    public static DialogueSpeaker speakerActual;

    [SerializeField]
    private DialogoUI dialUI;
    [SerializeField]
    private GameObject player;

    //float walkS, RunS;

    public ControladorPreguntas controladorPreguntas;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        dialUI = FindObjectOfType<DialogoUI>();
        controladorPreguntas = FindObjectOfType<ControladorPreguntas>();
        
    }
    private void Start()
    {
        //walkS = player.GetComponent<>().m_walkSpeed;
        //RunS = player.GetComponent<>().m_RunSpeed;
        MostrarUI(false);
        player.GetComponent<DialogueSpeaker>().Conversar();
    }

    public void MostrarUI( bool mostrar)
    {
        dialUI.gameObject.SetActive(mostrar);
        if (!mostrar)
        {
            dialUI.localIn = 0;
            //player.GetComponent<>().m_WalkSpeed = walks;

        }
        else
        {
            //player.GetComponent<>().m_WalkSpeed = 0;
        }



    }

    public void SetConversacion (Conversacion conv, DialogueSpeaker speaker)
    {
        
        if(speaker != null)
        {
            speakerActual = speaker;
        }
        else
        {
            //EN EL CASO DE SER SPEAKER NULL QUIERE DECIR QUE TENGA DE UNA PREGUNTA
            //POR LO  QUE RESETEO EL LOCALIN PAR REORDEN DE TODA LA NUEVA CONVERSION PRODUCTOS DE LA RESPUESTA ELEGIDA

            dialUI.conversacion = conv;
            dialUI.localIn = 0;
            dialUI.ActualizarTextos(0);
        }


        if (conv.finalizado && !conv.reUsar)
        {
            dialUI.conversacion = conv;
            dialUI.localIn = conv.dialogos.Length;
            dialUI.ActualizarTextos(1);
        }
        else
        {
            dialUI.conversacion = conv;
            dialUI.localIn = speakerActual.dialLocalIn;
            dialUI.ActualizarTextos(0);
        }

        

    }

    public void CambiarEstadoReUsado(Conversacion conv, bool estadoDeseado)
    {
        conv.reUsar = estadoDeseado;
    }

    //Funcion a llamar para desbloquear x conversacion

    //Funcion a llamar para desbloquer x converscion.
    public void BloquearYDesbloqueoDeConversacion(Conversacion conv, bool desbloquear)
    {
        conv.desbloqueada = desbloquear;
    }
}

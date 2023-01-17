using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions;

public class DialogueSpeaker : MonoBehaviour
{

    [ReorderableList]
    public List<Conversacion> conversacionesDisponible = new List<Conversacion>();

    [SerializeField]
    private int indexDeConversaciones = 0; // Recorre cada  conversacion dentro de la lista conversacionDisponble;

    public int dialLocalIn = 0;             // Recorre  cada dialogo dentro de la conversacion actual.


    // Start is called before the first frame update
    void Start()
    {
        indexDeConversaciones = 0;
        dialLocalIn = 0;
         //         DEBUG ONLY
        foreach (var conv in conversacionesDisponible)
        {
            conv.finalizado = false;
            var preg = conv.pregunta;
            if (preg != null)
            {
                foreach (var opcion in preg.opciones)
                {
                    opcion.convResultantes.finalizado = false;
                }
            }
        }
        //         DEBUG ONLY
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag ("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Conversar();
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
        {
            DialogoManager.instance.CambiarEstadoReUsado(conversacionesDisponible[indexDeConversaciones], !conversacionesDisponible[indexDeConversaciones].reUsar);

        }
    }

    public void Conversar()
    {
        if (indexDeConversaciones <= conversacionesDisponible.Count - 1)
        {
            if (conversacionesDisponible[indexDeConversaciones].desbloqueada)
            {
                if (conversacionesDisponible[indexDeConversaciones].finalizado)
                {
                    if (ActualizarConversacion())
                    {
                        DialogoManager.instance.MostrarUI(true);
                        DialogoManager.instance.SetConversacion(conversacionesDisponible[indexDeConversaciones], this);
                    }
                    DialogoManager.instance.SetConversacion(conversacionesDisponible[indexDeConversaciones], this);
                    return;
                }
                DialogoManager.instance.MostrarUI(true);
                DialogoManager.instance.SetConversacion(conversacionesDisponible[indexDeConversaciones], this);
            }
            else
            {
                Debug.LogWarning("La conversacion esta bloqueada");
                DialogoManager.instance.MostrarUI(false);
            }
        }
        else
        {
            //ya usa toda las conversaciones disponibles
            print("Fin del Dialogo");
            DialogoManager.instance.MostrarUI(false);
        }
    }

    bool ActualizarConversacion()
    {
        if (!conversacionesDisponible[indexDeConversaciones].reUsar)
        {
            if (indexDeConversaciones < conversacionesDisponible.Count - 1)
            {
                indexDeConversaciones++;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogoManager.instance.MostrarUI(false);
        }
    }
}

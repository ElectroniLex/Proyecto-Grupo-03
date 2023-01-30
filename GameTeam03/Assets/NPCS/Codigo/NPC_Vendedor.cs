using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Vendedor : MonoBehaviour
{
    public GameObject simboloCompra;
    //public PlayerController jugador;
    public GameObject NPCPanelInteracion;
    public GameObject NPCPanelMensaje;
    public GameObject panelNPCCompra;
    public TextMeshProUGUI textoCompra;
    public bool jugadorCerca;
    public bool aceptarCompra;
    public GameObject [] objetivos;
    public int numDeObjetivos;
    //public GameObject botonDeCompra;
    // Start is called before the first frame update
    void Start()
    {
        //textoCompra.text = "Hola, ¿Quieres adquirir un arma?";
        //jugador = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
        simboloCompra.SetActive(true);
        NPCPanelInteracion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && aceptarCompra == false)
        {
            //Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            //jugador.gameObject.transform.LookAt(posicionJugador);

            //jugador.anim.SetFloat("VelX", 0);
            //jugador.anim.SetFloat("VelY", 0);
            //jugador.enabled = false;
            NPCPanelInteracion.SetActive(false);
            NPCPanelMensaje.SetActive(true);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            //jugadorCerca = true;
            if (aceptarCompra == false)
            {
                NPCPanelInteracion.SetActive(true);
            }

           

        }
        


    }

    public void OntriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            jugadorCerca = false;

            NPCPanelInteracion.SetActive(false);
            NPCPanelMensaje.SetActive(false);
        }
    }

    public void Negativo()
    {
        //jugador.enabled = true;

        NPCPanelMensaje.SetActive(false);
        NPCPanelInteracion.SetActive(false);
    }

    public void Afirmativo()
    {
        //jugador.enabled = true;
        aceptarCompra = true;

        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        jugadorCerca = false;


        simboloCompra.SetActive(false);
        NPCPanelInteracion.SetActive(false);
        NPCPanelMensaje.SetActive(false);
        panelNPCCompra.SetActive(true);
    }
}

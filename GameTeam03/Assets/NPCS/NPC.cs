using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject simboloCompra;
    public PlayerController jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCCompra;
    public TextMeshProUGUI textoCompra;
    public bool jugadorCerca;
    public bool aceptarCompra;
    public GameObject [] objetivos;
    public int numDeObjetivos;
    public GameObject botonDeCompra;
    // Start is called before the first frame update
    void Start()
    {
        //textoCompra.text = "Hola, ¿Quieres adquirir un arma?";
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        simboloCompra.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.X) && aceptarCompra == false)
       {
           Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
           jugador.gameObject.transform.LookAt(posicionJugador);

           //jugador.anim.SetFloat("VelX", 0);
           //jugador.anim.SetFloat("VelY", 0);
           jugador.enabled = false;
           panelNPC.SetActive(false);
           panelNPC2.SetActive(true);
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            if (aceptarCompra == false)
            {
                panelNPC.SetActive(true);
            }
        }
    }

    private void OntriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;

            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }

    public void Negativo()
    {
        jugador.enabled = true;

        panelNPC2.SetActive(false);
        panelNPC.SetActive(false);
    }

    public void Afirmativo()
    {
        jugador.enabled = true;
        aceptarCompra = true;
        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        jugadorCerca = false;
        simboloCompra.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCCompra.SetActive(true);
    }
}

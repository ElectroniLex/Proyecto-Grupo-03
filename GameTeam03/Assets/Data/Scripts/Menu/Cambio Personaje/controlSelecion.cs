using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class controlSelecion : MonoBehaviour
{
    public ListaPersonajes lista_Personajes;
    public TextMeshProUGUI TMP_Nombre;
    public TextMeshProUGUI TMP_Descripcion;
    public Image lienzo_Referencia;

    private int contadorDePersonajes = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("contadorDePersonajes"))
        {
            contadorDePersonajes = 0;
        }
        else
        {
            Cargar();
        }
        ActualizarInformacion(contadorDePersonajes);
    }

    public void SiguientePersonaje()
    {
        contadorDePersonajes++;
        if (contadorDePersonajes>= lista_Personajes.contadorDePersonajes)
        {
            contadorDePersonajes = 0;
        }
        ActualizarInformacion(contadorDePersonajes);
        Guardar();
    }

    public void AnteriorPersonaje()
    {
        contadorDePersonajes--;

        if (contadorDePersonajes < 0)
        {
            contadorDePersonajes = lista_Personajes.contadorDePersonajes;
        }

        ActualizarInformacion(contadorDePersonajes);
    }

    public void ActualizarInformacion(int contador_personajes)
    {
        Ficha personaje = lista_Personajes.obtenerPersonaje(contador_personajes);
        lienzo_Referencia.sprite = personaje.imagen_Referencia;

        TMP_Nombre.text = personaje.nombre_Personaje;

        TMP_Descripcion.text = "Descripcion:" + personaje.descripcion_Personaje;

    }

    private void Guardar()
    {
        PlayerPrefs.SetInt("contadorDePersonajes", contadorDePersonajes);
    }

    private void Cargar()
    {
        contadorDePersonajes = PlayerPrefs.GetInt("contadorDePersonajes");
    }

}

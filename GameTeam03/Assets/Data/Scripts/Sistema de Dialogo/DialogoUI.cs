using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogoUI : MonoBehaviour
{
    public Conversacion conversacion; // LlAMA AL SCRIPT
    [SerializeField]
    private float textSpeed = 10;

    [SerializeField]
    private GameObject convContainer;
    [SerializeField]
    private GameObject pregContainer;

    [SerializeField]
    private Image speakIm;
    [SerializeField]
    private TextMeshProUGUI nombre;
    [SerializeField]
    private TextMeshProUGUI convText;

    [SerializeField]
    private Button continuarButton;

    private Button anteriorButton;

    private AudioSource audioSource;

    public int localIn = 1;                           //Recorre cada dialogo  dentro de la conversacion actual  (l omismo que "dialLocalIn")
                                                      //En DialogueSpeaker solo que este adopta el valor en base al que tenga puesto el DialogueSpeaker
                                                      //Al momento de hablar

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        convContainer.SetActive(true);
        convContainer.SetActive(false);

        continuarButton.gameObject.SetActive(true);
        anteriorButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActualizarTextos(1);
        }
    }

    private void ActualizarTextos (int comportamiento)
    {
        convContainer.SetActive(true);
        pregContainer.SetActive(false);

        switch (comportamiento)
        {
            case -1:
                if (localIn > 0)
                {
                    print("Dialogo anterior");
                    localIn--;

                    nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                    StopAllCoroutines();
                    StartCoroutine(EscribirTexto());
                    //convText.text = conversacion.dialogos[localIn].dialogo;        DIALOGO SIN ANIMACION
                    speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                    if (conversacion.dialogos[localIn].sonido != null)
                    {
                        audioSource.Stop();
                        audioSource.PlayOneShot(conversacion.dialogos[localIn].sonido);

                    }
                    anteriorButton.gameObject.SetActive(localIn > 0);

                }
                DialogoManager.speakerActual.dialLocalIn = localIn;
                break;

            // No avanzar con el texto
            case 0:
                print("Dialogo Actualizado");
                nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                StopAllCoroutines();
                StartCoroutine(EscribirTexto());
                //convText.text = conversacion.dialogos[localIn].dialogo;   
                speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                if (conversacion.dialogos[localIn].sonido != null)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(conversacion.dialogos[localIn].sonido);
                }
                anteriorButton.gameObject.SetActive(localIn > 0);

                if (localIn >= conversacion.dialogos.Length - 1)
                {
                    continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";

                }

                else
                {
                    continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continuar";
                }
                break;
                // Avanzar con el texto

            case 1:
                //El -1 es para evitar que salga del index del array dialogos
                
                if(localIn < conversacion.dialogos.Length - 1)
                {
                    print("Dialogos siguiente");
                    localIn++;
                    nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                    StopAllCoroutines();
                    StartCoroutine(EscribirTexto());
                    //convText.text = conversacion.dialogos[localIn].dialogo; 
                    speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                    if (conversacion.dialogos[localIn].sonido != null)
                    {
                        audioSource.Stop();
                        audioSource.PlayOneShot(conversacion.dialogos[localIn].sonido);

                    }

                    anteriorButton.gameObject.SetActive(localIn > 0);

                    if (localIn >= conversacion.dialogos.Length - 1)
                    {
                        continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";
                    }
                    else
                    {
                        continuarButton.GetComponentInChildren<TextMeshProUGUI>().text = "Continuar";
                    }

                }
                else
                {
                    print("Dialogo terminado");
                    localIn = 0;
                    DialogoManager.speakerActual.dialLocalIn = 0;
                    conversacion.finalizado = true;
                    /*
                    if(conversacion.pregunta != null)
                    {
                        convContainer.SetActive(false);
                        pregContainer.SetActive(true);
                        var preg = conversacion.pregunta;
                        DialogoManager.instance.controladorPreguntas.ActivarBotones(preg.opciones.Length, preg.pregunta, preg.opciones);
                        return;
                    }

                    */
                    DialogoManager.instance.MostrarUI(false);
                    return;
                }

                DialogoManager.speakerActual.dialLocalIn = localIn;
                break;

            default:
                Debug.LogWarning("Estas pasando un valor no admitido (solo se aceptan estos valores : -1, 0, 1,).");
                break;
        }

    }
    IEnumerator EscribirTexto()
    {
        convText.maxVisibleCharacters = 0;
        convText.text = conversacion.dialogos[localIn].dialogo;
        convText.richText = true;

        for (int i= 0; i < conversacion.dialogos[localIn].dialogo.ToCharArray().Length; i++)
        {
            convText.maxVisibleCharacters++;
            yield return new WaitForSeconds(1f / textSpeed);
        }
    }

  
}

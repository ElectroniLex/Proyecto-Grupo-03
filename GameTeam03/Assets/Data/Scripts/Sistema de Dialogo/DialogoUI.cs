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
    private Image speakim;
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
            //Retroceder con el text
            case -1:
                if (localIn > 0)
                {
                    print("Dialogo anterior");
                    localIn--;

                    nombre.text = conversacion.dialogos[localIn].sonido;
                    StopAllCoroutines();
                    StartCoroutine(EscribirTexto());
                    convText.text = conversacion.dialogos[localIn].dialogo;

                    speakim.sprite = conversacion.dialogos[localIn].personaje.image;

                    if (conversacion.dialogo[localIn].sonido != null)
                    {
                        audioSource.Stop();
                        var audio = conversacion.dialogo[localIn].sonido;
                        audioSource.PlayOneShot(audio);

                    }
                    anteriorButton.gameObject.SetActive(localIn > 0);

                }
                DialogoManager.speakerActual.dialLocalIn = localIn;
                break;

            // No avanzar con el texto

            
        }
            

         
        
        

    }
}

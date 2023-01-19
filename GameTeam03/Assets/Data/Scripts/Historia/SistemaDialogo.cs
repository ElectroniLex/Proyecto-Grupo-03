using System.Collections;
using UnityEngine;
using TMPro;

   public class SistemaDialogo : MonoBehaviour
{

    //*****************************************************************//
    //*****************************************************************//

    public CentralDeDialogo CentralDeDialogo;
    private bool Confirmar;
    public GameObject[] Panel;
    public TextMeshProUGUI[] TextoDialogo;

    public GameObject[] SiguienteObjc;
    public int[] OrdenDeDialogo;
   

    public Vector3 EscalaNormal = new Vector3 (1.0f, 1.0f, 1.0f);
    public Vector3 NuevaEscala = new Vector3(0.0f, 0.0f, 0.0f);
    public float EsperaDeEscala = 1;
    public float VelocidadDeCierre = 15;
    public float VelocidadTextos = 0.01f;
    public float DesactivarDialogo = 0.5f;

    [TextArea(3, 20)]
    public string[] ListaDialogos;
    bool Escalar;
    int Turno;
    int Index;
    int LimiteTexto;


    bool EsperarSonido;
    bool Llamado;
    bool IrAhSiguente;

   //public AudioSource source;
   //public AudioClip SonidoEscribir;

    //*****************************************************************//
    //*****************************************************************//
    void Start()
    {
      //  source = GetComponent<AudioSource>();
        LimiteTexto = ListaDialogos.Length -1;

        Desactivar();


    }
    //*****************************************************************//
    //*****************************************************************//
    void FixedUpdate()
    {

        Confirmar = Input.GetKeyDown(KeyCode.Return);

    }
    //*****************************************************************//
    //*****************************************************************//
    void Update()
    {
        if (Panel[Turno].activeInHierarchy 
            && Escalar)
        {
            Panel[Turno].transform.localScale = 
             Vector3.Lerp(Panel[Turno].transform.localScale, NuevaEscala, Time.deltaTime * VelocidadDeCierre);
        }
        if (Panel[Turno].activeInHierarchy
         && !Escalar)
        {
             Panel[Turno].transform.localScale =
             Vector3.Lerp(Panel[Turno].transform.localScale,EscalaNormal, Time.deltaTime * VelocidadDeCierre);
        }
        if (Confirmar
         && Panel[Turno].activeInHierarchy &&
            IrAhSiguente && !Escalar)
        {
            Siguente();
        }
        //*****************************************************************//
        if (Confirmar
        && Index == LimiteTexto &&
        IrAhSiguente)
        {
            StartCoroutine(DesactivarPanel());           
        }
        //*****************************************************************//
        if (IrAhSiguente && SiguienteObjc[Turno])
        {
            SiguienteObjc[Turno].SetActive(true);
        }
        //*****************************************************************//
        if (!IrAhSiguente && SiguienteObjc[Turno])
        {
            SiguienteObjc[Turno].SetActive(false);
        }
        //*****************************************************************//
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ActivarDialogo();
        }
    }
    //*****************************************************************//
    //*****************************************************************//
    public void ConfirmarUI()
    {
        if (Panel[Turno].activeInHierarchy &&
                   IrAhSiguente && !Escalar)
        {
            Siguente();
        }
        //*****************************************************************//
        if (Index == LimiteTexto &&
            IrAhSiguente)
        {
            StartCoroutine(DesactivarPanel());
        }
       
    }
    //*****************************************************************//
    //*****************************************************************//
    IEnumerator StartDialogo()
    {
   
        foreach (char Letra in ListaDialogos[Index].ToCharArray())
        {
            IrAhSiguente = false;
            TextoDialogo[Turno].text += Letra;

            StartCoroutine(Sonido());

            yield return new WaitForSeconds(VelocidadTextos);     
        }     

        if (Index <= ListaDialogos.Length - 1)
        {
            IrAhSiguente = true;
         
          }   
        }
    //*****************************************************************//
    //*****************************************************************//
    public void Siguente()
    {
        Escalar = true;

        for (int i = 0; i < SiguienteObjc.Length; i++)
        {
            SiguienteObjc[i].SetActive(false);
        }
        StartCoroutine(SiguienteDialogo());

    }

    //*****************************************************************//
    //*****************************************************************//
    IEnumerator SiguienteDialogo()
    {
   
        yield return new WaitForSeconds(EsperaDeEscala);

   
        if (Index < ListaDialogos.Length - 1)
        {
            Index++;
            Turno = OrdenDeDialogo[Index];
            TextoDialogo[Turno].text = "";
            Desactivar();
            Panel[Turno].SetActive(true);
            StartCoroutine(StartDialogo());
            Escalar = false;

        }

    }
        //*****************************************************************//
        //*****************************************************************//
        IEnumerator Sonido()
    {
        if (!EsperarSonido)
        {
            EsperarSonido = true;
         //   source.PlayOneShot(SonidoEscribir);
        }
        if (EsperarSonido)
        {
            yield return new WaitForSeconds(0.5f);

            EsperarSonido = false;
        }

    }

    //*****************************************************************//
    //*****************************************************************//
    public void ActivarDialogo()
    {
        if (!Llamado)
        {
            CentralDeDialogo.DialogoActivado = true;
            Turno = OrdenDeDialogo[Index];
            Panel[Turno].SetActive(true);
            Llamado = true;
            StartCoroutine(StartDialogo());
        }
    }
    //*****************************************************************//
    //*****************************************************************//
    void Desactivar()
    {
        for (int i = 0; i < TextoDialogo.Length; i++)
        {
            TextoDialogo[i].text = "";
        }
        for (int i = 0; i < SiguienteObjc.Length; i++)
        {
            SiguienteObjc[i].SetActive(false);
        }
    }

    //*****************************************************************//
    //*****************************************************************//
    IEnumerator DesactivarPanel()
    {
  
        yield return new WaitForSeconds(DesactivarDialogo);
        Desactivar();
        CentralDeDialogo.DialogoActivado = false;
        gameObject.SetActive(false);
  
    }
}
   //*****************************************************************//
   //*****************************************************************//
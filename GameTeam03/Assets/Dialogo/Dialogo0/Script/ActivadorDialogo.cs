using UnityEngine;

public class ActivadorDialogo : MonoBehaviour
{
    //*****************************************************************//
    public enum TipoInteracion
    {
        Nada, boton
    };
    //*****************************************************************//
    public TipoInteracion TipoDeInteracion;
    public string NombreDelPlayer = "Player";
    public SistemaDialogo SistemaDialogo;
    public GameObject BotonEntrada;
    private bool Activado;
    private bool Confirmar;

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
        if (Confirmar)
        {
            EvaluarInteracion();
        }
    }
    //*****************************************************************//
    //*****************************************************************//
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(NombreDelPlayer) && !Activado)
        {
            EvaluarInteracion();
        }
    }  
    
      //*****************************************************************//
      //*****************************************************************//

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(NombreDelPlayer) && !Activado)
        {
            BotonEntrada.SetActive(false);
        }
    }

    //*****************************************************************//
    //*****************************************************************//
    void EvaluarInteracion()
    {
        switch (TipoDeInteracion)
        {
            case TipoInteracion.Nada:

                SistemaDialogo.gameObject.SetActive(true);
                SistemaDialogo.ActivarDialogo();
                Activado = true;

                break;

            case TipoInteracion.boton:

                BotonEntrada.SetActive(true);

                if (Confirmar)
                {
                    BotonEntrada.SetActive(false);
                    SistemaDialogo.gameObject.SetActive(true);
                    SistemaDialogo.ActivarDialogo();
                    Activado = true;
                }

                break;

        }
    }
    //*****************************************************************//
    //*****************************************************************//
   public void ConfirmarUI()
    {
        BotonEntrada.SetActive(false);
        SistemaDialogo.gameObject.SetActive(true);
        SistemaDialogo.ActivarDialogo();
        Activado = true;
        Destroy(gameObject);
    }
    //*****************************************************************//
    //*****************************************************************//
}
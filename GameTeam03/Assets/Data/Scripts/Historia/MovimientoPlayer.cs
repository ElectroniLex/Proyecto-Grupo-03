using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    //*****************************************************************//
    //*****************************************************************//

    public CentralDeDialogo CentralDeDialogo; // Anadir este Script para que se comunicacon entre estos dos script

    public float VelocidadMovimiento = 6.0f;


    //*****************************************************************//
    //*****************************************************************//
    void Update()
    {
        if (!CentralDeDialogo.DialogoActivado) // Anadir este Codigo para que cuando el diologo comience el personaje no se pueda mover 

        {
            Movimiento();
        }

    }
    //*****************************************************************//
    //*****************************************************************//
    void Movimiento()
    {

        Vector3 Direccion = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        Vector3 Movimiento = Camera.main.transform.TransformDirection(Direccion);
        Movimiento.y = 0.0f;
        Movimiento.Normalize();


        transform.Translate(Movimiento * VelocidadMovimiento * Time.deltaTime);


    }
    //*****************************************************************//
    //*****************************************************************//
}

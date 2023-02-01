using UnityEngine;

public class DañoEnemigoMagoVerde : MonoBehaviour
{
    public int DañoRecibidoMagoAzul;
    public GameObject playerYazmin;
    //public Slider UIVida;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("player"))
        {
            Debug.Log("Enemigo Recibe daño");
            //El enemigo hace daño al jugador
            playerYazmin.GetComponent<PlayerYazmin>().vidaPlayer -= DañoRecibidoMagoAzul;
        }


    }
}

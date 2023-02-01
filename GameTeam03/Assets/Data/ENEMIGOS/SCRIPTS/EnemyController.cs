using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject PanelVidaEnemigoLagarto;
    public GameObject PanelVidaEnemigoMagoAzul;

    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;

    //public VidaEnemigoLagarto vidaEnemigo;

    public GameObject target;
    public bool atacando;


    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player-Yazmin");
    }

    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 15)
        {
            anim.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0 :
                    anim.SetBool("walk", false);
                    PanelVidaEnemigoMagoAzul.SetActive(false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    PanelVidaEnemigoMagoAzul.SetActive(false);
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    PanelVidaEnemigoMagoAzul.SetActive(false);
                    break;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position) > 10 && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                anim.SetBool("walk", false);

                anim.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                anim.SetBool("attack", false);

                PanelVidaEnemigoLagarto.SetActive(true);
                PanelVidaEnemigoMagoAzul.SetActive(true);
            }
            else
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", false);

                anim.SetBool("attack", true);
                
            }
        }
    }

    public void FinalAnimation()
    {
        anim.SetBool("attack", false);
        atacando = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }
}

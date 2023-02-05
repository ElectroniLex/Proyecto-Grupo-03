using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerLagarto : MonoBehaviour
{
    public GameObject PanelVidaEnemigoLagarto;

    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;

    public AudioSource audioCaminar;
    
    

    
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
                    PanelVidaEnemigoLagarto.SetActive(false);
                    audioCaminar.Stop();
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    PanelVidaEnemigoLagarto.SetActive(false);
                    audioCaminar.Stop();

                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    anim.SetBool("walk", true);
                    PanelVidaEnemigoLagarto.SetActive(false);

                    audioCaminar.Play();

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
                anim.SetBool("walk", false); // camina 

                anim.SetBool("run", true);// correr
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                audioCaminar.Play();

                anim.SetBool("attack", false);// atacar

                PanelVidaEnemigoLagarto.SetActive(true);

                
            }
            else
            {
                anim.SetBool("walk", false); // Desactiva la animacion de caminar
                anim.SetBool("run", false);// Desactiva la animacion de correr 
                anim.SetBool("attack", true); //Activa la animacion de atacar

                audioCaminar.Stop();


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

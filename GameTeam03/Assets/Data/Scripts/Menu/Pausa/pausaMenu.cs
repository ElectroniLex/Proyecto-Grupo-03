using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausaMenu : MonoBehaviour
{
    public static bool Pausa = false;
    public GameObject PausaMenuCanvas;


    void Start()
    {
        Time.timeScale = 1f;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
        
    }
    void Stop()
    {
        PausaMenuCanvas.SetActive(true);
        
        Time.timeScale = 0f;
        Pausa = true;
    }
    public void Play()
    {
        PausaMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        Pausa = false;

    }

    public void MainMenuButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadSceneAsync("Menu");
    }

     


}

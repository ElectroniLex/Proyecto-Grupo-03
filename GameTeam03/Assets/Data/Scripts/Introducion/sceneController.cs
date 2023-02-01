using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    public string scenaLoadName;
    public TextMeshProUGUI textProgress;
    public Slider sliderProgress;
  

    public float currentPercent;

    public void LoadSceneButton()
    {
        StartCoroutine(LoadScene(scenaLoadName));
        
    }
    public IEnumerator LoadScene(string nameToLoad)
    {
        textProgress.text = "Cargando.. 00%";
        AsyncOperation loadAsync =  SceneManager.LoadSceneAsync(nameToLoad);

        while (!loadAsync.isDone)
        {

            currentPercent = loadAsync.progress * 100 / 0.9f;
            textProgress.text = "Cargando.. "+currentPercent.ToString("00") + "%";
            sliderProgress.value = currentPercent;
            yield return null;
        }
    }

    private void Update()
    {
        sliderProgress.value = Mathf.MoveTowards(sliderProgress.value, currentPercent, 10 * Time.deltaTime);
    }
}

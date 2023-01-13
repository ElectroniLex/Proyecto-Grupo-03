using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturarPantalla : MonoBehaviour
{
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.P))
        {
            string screenshotTime = System.DateTime.Now.ToString("hh-mm-ss");
            ScreenCapture.CaptureScreenshot("screenshot" + screenshotTime + ".PNG");

        }
         
    }

}

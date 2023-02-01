using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Changer : MonoBehaviour
{
    [SerializeField] private Material skybox;
    private float _elapsedTime = 0f;
    private float _timeScale = 2.5f;
    private static readonly int Rotation = Shader.PropertyToID("_Rotation");
    private static readonly int Exposure = Shader.PropertyToID("_Exposure");


    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        skybox.SetFloat(Rotation, _elapsedTime * _timeScale);
        skybox.SetFloat(Exposure, Mathf.Clamp(Mathf.Sin(_elapsedTime), 0.15f, 1f));

    }
}
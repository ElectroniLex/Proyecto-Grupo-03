using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int vida;
    public int score;

    [SerializeField] private TMP_Text vidaText;
    [SerializeField] private TMP_Text scoreText;

    private float hInput;
    private float vInput;
    private float speed = 5f;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Slider hitSlider;
    private int oldValue;
    public float hitDelay = 0.5f;
    float nextUpdate;
    bool updating = false;

    public override void ChangeMaxValue(int maxValue)
    {
        base.ChangeMaxValue(maxValue);
        hitSlider.maxValue = maxValue; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

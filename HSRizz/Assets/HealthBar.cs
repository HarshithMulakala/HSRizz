using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetHealth(float health){
        fill.color = gradient.Evaluate(slider.normalizedValue);
        slider.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

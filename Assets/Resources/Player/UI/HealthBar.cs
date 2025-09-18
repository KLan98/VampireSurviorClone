using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerDamageReceiver damageReceiver;
    private Slider slider;
    
    // private fields
    private int counter;
    private int maxCounter;
    private float maxHealthSlider;
    private float minHealthSlider;
    private float interpolationValue;

    private void Awake()
    {
        LoadSlider();
        maxHealthSlider = slider.maxValue;
        minHealthSlider = slider.minValue;

        // init physics update counter
        maxCounter = 5;
        counter = maxCounter;
        // Debug.Log($"[{gameObject.name}] Init value of counter = {counter}, maxCounter = {maxCounter}");  
    }

    private void LoadSlider()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Lerp the slider with player's health
    private void ScaleSlider()
    {
        interpolationValue = (float)damageReceiver.CurrentHealth/(float)damageReceiver.MaxHealth;
        // Debug.Log($"Interpolation value = {interpolationValue}");

        // change the slider value
        slider.value = Mathf.Lerp(minHealthSlider, maxHealthSlider, interpolationValue);

        // Debug.Log($"Slider value = {slider.value}");
    }

    private void Update()
    {
        counter = counter - 1;
        if (counter <= 0)
        {
            ScaleSlider();

            counter = maxCounter;
        }
    }
}

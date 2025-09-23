using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    private readonly CombatState combatState = new CombatState();

    [Header("Optimization fields")]
    private float updateTime = 1f; // TimerBar is to be updated every 1 second
    private float updateCounter; // up counter, value changed everyframe

    [Header("Timer bar fields")]
    [SerializeField] private float timeInSecond; // real time in second
    private float startTime = 1200f; // level starts at 20 minutes = 1200 second
    private float sliderInitValue = 1f;
    private float interpolationValue;

    [Header("Components")]
    [SerializeField] private Slider slider;

    private void Awake()
    {
        LoadSlider();

        timeInSecond = startTime; // 120 seconds

        slider.value = sliderInitValue;
    }

    private void LoadSlider()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        CheckCurrentGameState();
        
        updateCounter += Time.deltaTime;

        if (updateCounter >= updateTime)
        {
            timeInSecond -= 1; // subtract by 1 for each second passing

            ScaleTimerSlider(); // scale the slider according to timeInSecond

            updateCounter = 0f;
        }
    }

    // Lerp the slider with current time
    private void ScaleTimerSlider()
    {
        interpolationValue = (float)timeInSecond/(float)startTime;
        // Debug.Log($"Interpolation value = {interpolationValue}");

        slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, interpolationValue);
        // Debug.Log($"Slider value = {slider.value}");
    }

    private void CheckCurrentGameState()
    {
        if (GameStateManager.Instance.GetCurrentGameState().GetType() != combatState.GetType())
        {
            Debug.Log($"Timer will not count down, current game state = {GameStateManager.Instance.GetCurrentGameState()}");
            return;
        }
    }
}

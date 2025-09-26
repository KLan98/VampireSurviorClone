using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    private readonly CombatState combatState = new CombatState();

    [Header("Performance optimization fields")]
    private float updateTime = 1f; // TimerBar is to be updated every 1 second
    private float updateCounter; // up counter, value changed everyframe

    [Header("Timer bar fields")]
    [SerializeField] private float timeInSecond; // real time in second

    // properties
    public float MainTimer // Main timer in seconds
    {
        get
        {
            return timeInSecond;
        }
    }

    // private fields
    private float startTime = 1200f; // level starts at 20 minutes = 1200 second
    private float sliderInitValue = 1f;
    private float interpolationValue;
    private int currentMinute;

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

            // Check if 1 minute has passed then trigger choose reward state
            if (OneMinuteHasPassed() == true)
            {
                EventManager.TriggerChooseRewardState();
            }

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

    // timer only counts when game state = combat
    private void CheckCurrentGameState()
    {
        if (GameStateManager.Instance.GetCurrentGameState().GetType() != combatState.GetType())
        {
            // Debug.Log($"Timer will not count down, current game state = {GameStateManager.Instance.GetCurrentGameState()}");
            return;
        }
    }

    private int GetMinuteIndex()
    {
        int minuteIndex = Mathf.CeilToInt(MainTimer / 60f); // current minute 

        return minuteIndex;
    }

    private bool OneMinuteHasPassed()
    {
        if (MainTimer % 60 == 0 && MainTimer >= 0)
        {
            Debug.Log("One minute has passed");
            return true;
        }

        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button m_ExitButton;

    private void LoadExitButton()
    {
        m_ExitButton = gameObject.GetComponent<Button>();
    }

    private void Awake()
    {
        LoadExitButton();
    }

    private void OnEnable()
    {
        m_ExitButton.onClick.AddListener(QuitApplication);        
    }

    private void QuitApplication()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}

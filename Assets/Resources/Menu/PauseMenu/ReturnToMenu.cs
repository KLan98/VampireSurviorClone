using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour
{
    private Button m_ReturnToMenuButton;

    private void LoadReturnToMenuButton()
    {
        m_ReturnToMenuButton = gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        m_ReturnToMenuButton.onClick.AddListener(SceneTransition);   
    }

    private void Awake()
    {
        LoadReturnToMenuButton();
    }

    private void SceneTransition()
    {
        Debug.Log("Return to menu");
        SceneManager.LoadScene("Menu");
    }
}

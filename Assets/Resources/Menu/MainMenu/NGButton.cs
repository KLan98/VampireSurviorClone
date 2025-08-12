using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NGButton : MonoBehaviour
{
    private Button m_NGButton;

    private void OnEnable()
    {
        m_NGButton.onClick.AddListener(SceneTransition);
    }

    private void Awake()
    {
        LoadStartButton();
    }

    private void SceneTransition()
    {
        Debug.Log("Play button clicked");
        SceneManager.LoadScene("Game");
    }

    private void LoadStartButton()
    {
        m_NGButton = gameObject.GetComponent<Button>();
    }
}

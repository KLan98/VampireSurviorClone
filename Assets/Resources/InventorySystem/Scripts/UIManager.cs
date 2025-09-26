using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scripts serves as an access point for all UI elements
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Weapon Select Menu")]
    public GameObject weaponSelectionUI;

    [Header("Pause Menu")]
    public GameObject pauseMenuUI;
    public GameObject pauseMenuUI_slotGameObject;

    [Header("Player health bar")]
    public GameObject playerHealthBarCanvasUI;

    [Header("Game over screen")]
    public GameObject gameOverScreen;

    [Header("Choose reward")]
    public GameObject chooseReward;

    [Header("Upgrade select meu")]
    public GameObject upgradeSelectionUI;

    private void Awake()
    {
        Instance = this;
    }
}

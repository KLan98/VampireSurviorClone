using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeRewardOption : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        LoadButton();
        button.onClick.AddListener(TriggerUpgradeSelection);
    }

    private void LoadButton()
    {
        button = gameObject.GetComponent<Button>();
    }

    private void TriggerUpgradeSelection()
    {
    }
}

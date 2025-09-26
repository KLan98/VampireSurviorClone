using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWeaponRewardOption : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        LoadButton();
        button.onClick.AddListener(TriggerWeaponSelection);
    }

    private void LoadButton()
    {
        button = gameObject.GetComponent<Button>();
    }

    private void TriggerWeaponSelection()
    {
        GameStateManager.Instance.ChangeState(new ChooseWeaponState());
    }
}

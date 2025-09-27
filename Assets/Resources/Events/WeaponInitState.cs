using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInitState : GameState
{
    public override void Enter(GameStateManager gameStateManager)
    {
        base.Enter(gameStateManager);

        ScanInventory(gameStateManager);
    }

    // scan inventory for initializable weapons
    private void ScanInventory(GameStateManager gameStateManager)
    {
        // Debug.Log("Trigger scan inventory");
        SlotClass[] itemDB = gameStateManager.InventoryManager.ItemDB;
        for (int i = 0; i < itemDB.Length; i++)
        {
            if (itemDB[i] == null)
            {
                // exit the loop if meet a null item slot
                break;
            }

            else
            {
                // Debug.Log(itemDB[i].GetItem().ItemName);
                // if the item is newly added and its projectile pattern = orbit then trigger spawn orbit attack event
                if (itemDB[i].GetItem().NewWeaponAdded && itemDB[i].GetItem().ProjectilePattern == IItem.BulletPattern.Orbit)
                {
                    EventManager.TriggerSpawnOrbitAttack();
                    // Debug.Log("Event TriggerSpawnOrbitAttack executed");
                }
            }
        }

        // Debug.Log("Scanning completed");
        GameStateManager.Instance.ChangeState(new CombatState());
    }

    public override void Exit()
    {
        base.Exit();
    }
}

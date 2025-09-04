using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    private PlayerControl playerControl;
    private AttackScheduler scheduler;
    private IBulletSpawnerRegistry spawnerRegistry;
    private ITimeProvider timeProvider;

    public PlayerAttack(PlayerControl playerControl, AttackScheduler scheduler, IBulletSpawnerRegistry spawnerRegistry, ITimeProvider timeProvider)
    {
        this.playerControl = playerControl;
        this.scheduler = scheduler;
        this.spawnerRegistry = spawnerRegistry;
        this.timeProvider = timeProvider;
    }

    // Spawn attack through scheduler 
    public void SpawnAttacks()
    {
        scheduler.UpdateWeaponFiring(playerControl.inventoryManager.ItemDB, playerControl.transform.position);
    }
}

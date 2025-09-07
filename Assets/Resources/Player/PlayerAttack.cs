using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    private PlayerControl playerControl;
    private AttackScheduler scheduler;
    private IBulletSpawnerRegistry spawnerRegistry;
    private ITimeProvider timeProvider;
    private OrbitAttackInit orbitAttackInit;

    public PlayerAttack(PlayerControl playerControl, AttackScheduler scheduler, OrbitAttackInit orbitAttackInit, IBulletSpawnerRegistry spawnerRegistry, ITimeProvider timeProvider)
    {
        this.playerControl = playerControl;
        this.scheduler = scheduler;
        this.orbitAttackInit = orbitAttackInit;
        this.spawnerRegistry = spawnerRegistry;
        this.timeProvider = timeProvider;
    }

    // Spawn attack through scheduler 
    public void SpawnScheduledAttacks()
    {
        scheduler.UpdateWeaponFiring(playerControl.inventoryManager.ItemDB, playerControl.transform.position);
    }

    public void SpawnOrbitAttack()
    {
        orbitAttackInit.OrbitAttackSpawnPositionOffset(playerControl.inventoryManager.ItemDB, playerControl.transform.position);
    }
}

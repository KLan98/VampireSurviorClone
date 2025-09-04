using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Orbit attacks only need to be spawned once!
/// <summary>
public class OrbitAttackInit
{
    // A registry that knows how to spawn bullets for each type of weapon
	private readonly IBulletSpawnerRegistry spawners;

    public OrbitAttackInit(IBulletSpawnerRegistry spawners)
    {
        this.spawners = spawners;
    }

    public void SpawnOrbitAttack(IEnumerable<SlotClass> slots, Vector3 spawnPosition)
    {
		// If there are no slots to check, stop here
		if (slots == null)
		{
			return;
		}

		// Go through each slot (slot can contain a weapon)
		foreach (SlotClass slot in slots)
		{
			// If the slot itself is empty, skip it
			if (slot == null)
			{
				continue;
			}

			// Try to get the weapon from the slot
			WeaponClass weapon = slot.GetItem() as WeaponClass;
			if (weapon == null)
			{
				// If the slot doesn't contain a weapon, skip it
				continue;
			}

			// Use the weapon's name as a unique ID
			string weaponId = weapon.ItemName;

			if (weapon.ProjectilePattern == ItemScriptableObject.BulletPattern.Orbit)
			{
                // If enough time has passed, try to get a bullet spawner for this weapon
				if (spawners.TryGetSpawner(weaponId, out IBulletSpawner spawner))
				{
					// // Spawn as many projectiles as the weapon says it should
					// for (int i = 0; i < weapon.NumberOfProjectiles; i++)
					// {
						// Spawn the projectile at the given position
						spawner.Spawn(spawnPosition + new Vector3(0 , 1, 0));
					// }
				}
            }
        }
    }
}
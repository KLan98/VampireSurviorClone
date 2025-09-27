using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Orbit attacks only need to be spawned once!
/// <summary>
public class OrbitAttackInit
{
    // A registry that knows how to spawn bullets for each type of weapon
	private IBulletSpawnerRegistry spawners;

    public OrbitAttackInit(IBulletSpawnerRegistry spawners)
    {
        this.spawners = spawners;
    }

	/// <summary>
	/// spawn orbit attacks revolve a pivot
	/// <summary>
    public void OrbitAttackSetInitPivot(IEnumerable<SlotClass> slots, Vector3 pivotPosition)
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

			if (weapon.ProjectilePattern == IItem.BulletPattern.Orbit)
			{
				if (spawners.TryGetSpawner(weaponId, out IBulletSpawner spawner))
				{
					// Spawn as many projectiles as the weapon says it should
					for (int i = 0; i < weapon.NumberOfProjectiles; i++)
					{
						float angle = i * Mathf.PI * 2f / weapon.NumberOfProjectiles;

						// Debug.Log("spawn angle = " + angle * 180 / Math.PI);

						// Direction on XY plane
						Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);

						// Position offset
						Vector3 spawnPos = pivotPosition + dir * weapon.ProjectileRadius;

						// Debug.Log($"spawn position = {spawnPos}");

						// Spawn the projectile at the given position
						spawner.Spawn(spawnPos);
						// Debug.Log($"Bullet {weapon.ItemName} spawned at position {spawnPos}");
					}
				}
            }
        }
    }
}
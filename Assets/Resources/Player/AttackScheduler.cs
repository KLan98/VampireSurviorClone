using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used for weapons with projectile patterns = straight, boomerang
/// <summary>
public class AttackScheduler
{
	// A registry that knows how to spawn bullets for each type of weapon
	private IBulletSpawnerRegistry spawners;

	// Provides the time difference between frames (DeltaTime)
	private ITimeProvider time;

	// Keeps track of cooldown time for each weapon by name
	// Key = weapon name (string), Value = time passed since last shot (float)
	private Dictionary<string, float> cooldownElapsed = new Dictionary<string, float>();

	// Constructor: we pass in the spawner system and the time provider
	public AttackScheduler(IBulletSpawnerRegistry spawners, ITimeProvider time)
	{
		this.spawners = spawners;
		this.time = time;
	}

	// This method is called every frame to update weapon firing
	public void UpdateWeaponFiring(IEnumerable<SlotClass> slots, Vector3 spawnPosition)
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

			if (weapon.ProjectilePattern == IItem.BulletPattern.Straight)
			{
				// If this is the first time we see this weapon, start its cooldown timer at 0
				if (!cooldownElapsed.ContainsKey(weaponId))
				{
					cooldownElapsed[weaponId] = 0f;
				}

				// Add the time that passed since last frame to the weapon's cooldown timer
				cooldownElapsed[weaponId] += time.DeltaTime;

				// If the cooldown timer hasn't reached the weapon's cooldown requirement, skip firing
				if (cooldownElapsed[weaponId] < weapon.CoolDownTime)
				{
					continue;
				}

				// If enough time has passed, try to get a bullet spawner for this weapon
				if (spawners.TryGetSpawner(weaponId, out IBulletSpawner spawner))
				{
					// Spawn as many projectiles as the weapon says it should
					for (int i = 0; i < weapon.NumberOfProjectiles; i++)
					{
						// Spawn the projectile at the given position
						spawner.Spawn(spawnPosition);
					}
				}

				// Reset the cooldown timer for this weapon, since it just fired
				cooldownElapsed[weaponId] = 0f;
			}
		}
	}
}

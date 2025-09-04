using UnityEngine;

public interface IBulletSpawnerRegistry
{
	bool TryGetSpawner(string weaponId, out IBulletSpawner spawner);
}
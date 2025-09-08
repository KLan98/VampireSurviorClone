using UnityEngine;
using System.Collections.Generic;

public class BulletSpawnerRegistry : IBulletSpawnerRegistry
{
	private Dictionary<string, IBulletSpawner> map;

	public BulletSpawnerRegistry()
	{
		map = new Dictionary<string, IBulletSpawner>
		{
			{ "Shotgun", new DelegateSpawner(position => ShotgunBulletPool.Instance.SpawnBullet(position)) },
			{ "Heugabel", new DelegateSpawner(position => HeugabelBulletPool.Instance.SpawnBullet(position)) },
			{ "Schaufel", new DelegateSpawner(position => SchaufelBulletPool.Instance.SpawnBullet(position)) },
			{ "Sichel", new DelegateSpawner(position => SichelBulletPool.Instance.SpawnBullet(position)) },
		};
	}

	public bool TryGetSpawner(string id, out IBulletSpawner spawner) => map.TryGetValue(id, out spawner);

	private class DelegateSpawner : IBulletSpawner
	{
		private System.Action<Vector3> spawnAction;
		public DelegateSpawner(System.Action<Vector3> spawnAction) { this.spawnAction = spawnAction; }
		public void Spawn(Vector3 position) => spawnAction(position);
	}
}
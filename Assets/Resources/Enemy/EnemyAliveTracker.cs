using UnityEngine;

public class EnemyAliveTracker : MonoBehaviour
{
    public static EnemyAliveTracker Instance { get; private set; }

    [Tooltip("Current count of alive enemies. Updated by spawners and despawns.")]
    [SerializeField] private int aliveCount;
    public int AliveCount
    {
        get
        {
            return aliveCount;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void OnEnemySpawned()
    {
        aliveCount++;
    }

    public void OnEnemyDespawned()
    {
        if (aliveCount > 0)
        {
            aliveCount--;
        }
    }
}



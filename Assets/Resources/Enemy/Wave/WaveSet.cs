using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/WaveSet", fileName = "WaveSet")]
public class WaveSet : ScriptableObject
{
    [Tooltip("Each element is a one-minute wave. Last wave repeats once list ends.")]
    [SerializeField] private List<Wave> waves = new List<Wave>();
    public List<Wave> Waves
    {
        get
        {
            return waves;
        }
    }
}

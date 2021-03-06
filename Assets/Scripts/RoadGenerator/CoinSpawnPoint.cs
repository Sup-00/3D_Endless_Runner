using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    public SpawnPoint[] SpawnPoints { get; private set; }

    private void Awake()
    {
        SpawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
}

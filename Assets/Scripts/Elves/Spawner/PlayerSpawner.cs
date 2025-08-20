using UnityEngine;
using Zenject;

public class PlayerSpawner
{
    private readonly DiContainer _container;
    private readonly GameObject[] _playerPrefab;
    private readonly GameObject[] _spawnPosition;
    private readonly int _playerCount = 4;

    public PlayerSpawner(DiContainer container, GameObject[] playerPrefab, GameObject[] spawnPosition)
    {
        _container = container;
        _playerPrefab = playerPrefab;
        _spawnPosition = spawnPosition;

        for (int i = 0; i < _playerCount; i++) {
            SpawnPlayer(_spawnPosition[i].transform.position, Quaternion.identity, _playerPrefab[i]);
        }
    }

    public void SpawnPlayer(Vector3 position, Quaternion rotation, GameObject playerPrefab)
    {
        var player = _container.InstantiatePrefab(playerPrefab, position, rotation, null);
        player.SetActive(true);
        player.gameObject.SetActive(true);
    }
}
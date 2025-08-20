using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameObject[] playerPrefab;
    [SerializeField] private GameObject[] spawnPosition;

    public override void InstallBindings()
    {
        Container.Bind<PlayerSpawner>()
            .AsSingle()
            .WithArguments(playerPrefab, spawnPosition).NonLazy();
    }
}
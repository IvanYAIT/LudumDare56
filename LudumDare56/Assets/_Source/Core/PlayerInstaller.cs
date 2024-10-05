using Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PickUpData pickUpData;

    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(playerData).AsSingle().NonLazy();
        Container.Bind<PickUpData>().FromInstance(pickUpData).AsSingle().NonLazy();
        Container.Bind<PlayerController>().AsSingle().NonLazy();
    }
}
using Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PickUpData pickUpData;
    [SerializeField] private PauseMenu pauseMenu;

    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(playerData).AsSingle().NonLazy();
        Container.Bind<PickUpData>().FromInstance(pickUpData).AsSingle().NonLazy();
        Container.Bind<PauseMenu>().FromInstance(pauseMenu).AsSingle().NonLazy();
        Container.Bind<PlayerController>().AsSingle().NonLazy();
        Container.Bind<PickUpSystem>().AsSingle().NonLazy();
    }
}
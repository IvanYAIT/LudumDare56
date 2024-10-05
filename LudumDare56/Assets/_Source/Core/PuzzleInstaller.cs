using BasketBallPuzzle;
using BowPuzzle;
using UnityEngine;
using Zenject;

public class PuzzleInstaller : MonoInstaller
{
    [SerializeField] private BallData ballData;
    [SerializeField] private LayerMask shootZoneLayer;
    [SerializeField] private CameraPositionData cameraPositionData;
    [SerializeField] private BowData bowData;

    public override void InstallBindings()
    {
        Container.Bind<CameraPositionData>().FromInstance(cameraPositionData).AsSingle().NonLazy();
        Container.Bind<LayerMask>().FromInstance(shootZoneLayer).AsSingle().NonLazy();

        Container.Bind<BallData>().FromInstance(ballData).AsSingle().NonLazy();
        Container.Bind<BallController>().AsSingle().NonLazy();

        Container.Bind<BowData>().FromInstance(bowData).AsSingle().NonLazy();
        Container.Bind<BowController>().AsSingle().NonLazy();
    }
}
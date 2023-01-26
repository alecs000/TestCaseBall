using UnityEngine;
using Zenject;

public class ControlInstaller : MonoInstaller
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _startPoint;
    public override void InstallBindings()
    {
        BindInputService();
        BindPlayerStartSpeed();
        BindPlayerMovement();
    }

    private void BindInputService()
    {
        Container
        .Bind<IInputService>()
        .To<InputService>()
        .FromInstance(_inputService)
        .AsSingle();
    }
    private void BindPlayerStartSpeed()
    {
        Container
            .Bind<PlayerStartSpeed>()
            .AsSingle();
    }
    private void BindPlayerMovement()
    {
        PlayerMovement playerMovement = Container.InstantiatePrefabForComponent<PlayerMovement>(_playerMovement, _startPoint.position, Quaternion.identity, null);
        Container.
            Bind<PlayerMovement>()
            .FromInstance(playerMovement)
            .AsSingle();
    }
}

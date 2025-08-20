using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CharacterControlScript _character;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField]  private Camera _mainCamera;
    
    public override void InstallBindings()
    {
        Container.Bind<Animator>().FromInstance(_animator).AsSingle();
        Container.Bind<NavMeshAgent>().FromInstance(_agent).AsSingle();
        Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();
        Container.Bind<IInputController>().To<MouseInputController>().AsSingle().NonLazy();
        Container.Bind<IMovementController>().To<NavMeshMovementController>().AsSingle().NonLazy();
        Container.Bind<IAnimationController>().To<AnimatorController>().AsSingle().NonLazy();
    
        Container.Bind<CharacterControlScript>().FromInstance(_character).AsSingle();
    }
}

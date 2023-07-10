using UnityEngine;
using Zenject;

public class WinSystemInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _winSystemPrefab;

    public override void InstallBindings()
    {
        WinSystem winSystemInstance = Container.InstantiatePrefabForComponent<WinSystem>
           (_winSystemPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<WinSystem>().FromInstance(winSystemInstance).AsSingle().NonLazy();
    }
}
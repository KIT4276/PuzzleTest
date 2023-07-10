using UnityEngine;
using Zenject;

public class UIRayCastInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _uIRayCastPPrefab;
    
    public override void InstallBindings()
    {
        UIRayCast uIRayCastInstance = Container.InstantiatePrefabForComponent<UIRayCast>
            (_uIRayCastPPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<UIRayCast>().FromInstance(uIRayCastInstance).AsSingle().NonLazy();
    }
}
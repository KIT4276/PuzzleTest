using UnityEngine;
using Zenject;

public class DataHolderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DataHolder>().AsSingle();
    }
}
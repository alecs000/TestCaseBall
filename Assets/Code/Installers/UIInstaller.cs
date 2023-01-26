using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UILoseMenu _UILoseMenu;
    [SerializeField] private UIStartMenu _UIStartMenu;

    public override void InstallBindings()
    {
        BindLoseMenu();
        BindStartMenu();
    }

    private void BindStartMenu()
    {
        Container
                    .Bind<UIStartMenu>()
                    .FromInstance(_UIStartMenu)
                    .AsSingle();
    }

    private void BindLoseMenu()
    {
        Container
                    .Bind<UILoseMenu>()
                    .FromInstance(_UILoseMenu)
                    .AsSingle();
    }
}

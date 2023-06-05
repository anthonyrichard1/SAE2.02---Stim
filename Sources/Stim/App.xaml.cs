﻿using Model;
using StimPersistance;
using StimStub;
using System.Diagnostics;

namespace Stim;

public partial class App : Application
{
    public Manager Manager { get; set; }
    public App()
    {
        InitializeComponent();
        MainPage = new LoginPage();
        if (File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "games.xml"))) Manager = new Manager(new Persistance(FileSystem.Current.AppDataDirectory));
        else Manager = new(new Stub());
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Stopped += (s, e) =>
        {
            if (!(File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "games.xml"))))
            {
                Manager Manager2 = new(new Persistance(FileSystem.Current.AppDataDirectory));
                Manager2.GameList = Manager.GameList;
                Manager2.Users = Manager2.Users;
                Manager2.SaveGames();
                Manager2.SaveUser();
            }
            else
            {
                Manager.SaveGames();
                Manager.SaveUser();
            }            
        };

        return window;
    } 
}

using System;
using System.Collections.Generic;
using Domain;
using UniRx;

namespace InterfaceAdapters.MainView
{
    public class InstallerViewModel
    {
        public readonly ReactiveCommand<string> LoadDataFromWebSite;
        public readonly ReactiveProperty<List<UserData>> ListOfUserData; 

        public InstallerViewModel()
        {
            LoadDataFromWebSite = new ReactiveCommand<string>();
            ListOfUserData = new ReactiveProperty<List<UserData>>();
        }

        public Action<string> loadDataFromWebSiteAlter;
        public Action<List<UserData>> listOfUserDataAlter;
    }
}
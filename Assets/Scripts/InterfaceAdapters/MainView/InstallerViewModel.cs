using System;
using System.Collections.Generic;
using Domain;

namespace InterfaceAdapters.MainView
{
    public class InstallerViewModel
    {
        public Action<string> loadDataFromWebSiteAlter;
        public Action<List<UserData>> listOfUserDataAlter;
    }
}
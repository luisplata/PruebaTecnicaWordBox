using System;
using System.Collections.Generic;
using Domain;
using UnityEngine;
using Utils;

namespace InterfaceAdapters.MainView
{
    public class InstallerPresenter : IFinishedLoadDataFromServer, IDisposable
    {
        private readonly InstallerViewModel _model;
        private List<IDisposable> _disposables;

        public InstallerPresenter(InstallerViewModel model)
        {
            _disposables = new List<IDisposable>();
            _model = model;
        }
        public async void LoadData(RandomUserData randomUserData)
        {
            var userData = new List<UserData>();
            Debug.Log($"In presenter data");
            foreach (var result in randomUserData.results)
            {
                var item = new UserData(result);
                await item.LoadPicture();
                userData.Add(item);
            }
            _model.listOfUserDataAlter?.Invoke(userData);
        }

        public void Dispose()
        {
            
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
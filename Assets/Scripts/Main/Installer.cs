using System;
using System.Collections.Generic;
using Domain;
using InterfaceAdapters.MainView;
using UnityEngine;
using Utils;
using View;

namespace Main
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private StartLoadingDataFromServer loading;
        [SerializeField] private ShowDataInBigPanel showDataInBigPanel;
        private List<IDisposable> _disposables;
        private InstallerPresenter _installerPresenter;
        private InstallerController _installerController;

        private void Awake()
        {
            _disposables = new List<IDisposable>();
            ServiceLocator.Instance.RegisterService<IShowDataInBigPanel>(showDataInBigPanel);
            
            var installerViewModel = new InstallerViewModel();

            var requestDataFromServer = new RequestDataFromServer();
            _installerController = new InstallerController(installerViewModel, requestDataFromServer);
            _disposables.Add(_installerController);
            
            _installerPresenter = new InstallerPresenter(installerViewModel);
            ServiceLocator.Instance.RegisterService<IFinishedLoadDataFromServer>(_installerPresenter);
            _disposables.Add(_installerPresenter);
            
            loading.Configure(installerViewModel);
            
        }

        private void OnDestroy()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
            ServiceLocator.Instance.RemoveService<IShowDataInBigPanel>(showDataInBigPanel);
            ServiceLocator.Instance.RemoveService<IFinishedLoadDataFromServer>(_installerPresenter);
        }
    }
}
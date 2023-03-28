using System;
using System.Collections.Generic;
using InterfaceAdapters.MainView;
using UniRx;
using UniRx.Diagnostics;
using UnityEngine;

namespace View
{
    public class StartLoadingDataFromServer : MonoBehaviour
    {
        [SerializeField] private string url;
        [SerializeField] private ShowDataListInView showData;
        private InstallerViewModel _viewModel;
        private List<IDisposable> _disposables;

        public void Configure(InstallerViewModel viewModel)
        {
            _disposables = new List<IDisposable>();
            _viewModel = viewModel;
            Debug.Log($"Start request");
            _viewModel.loadDataFromWebSiteAlter?.Invoke(url);
            Debug.Log($"request invoked");
            //_viewModel.LoadDataFromWebSite.ForceExecute(url);

            /*_viewModel.ListOfUserData.Subscribe((list) =>
            {
                //Debug.Log($"load data in view");
                //Instantiate objects and configure de contain in view
                //showData.LoadData(list);
            }).AddTo(_disposables);*/
            _viewModel.listOfUserDataAlter += list =>
            {
                Debug.Log($"load data in view alter");
                //Instantiate objects and configure de contain in view
                showData.LoadData(list);
            };
        }
        
        private void OnDestroy()
        {
            _viewModel.listOfUserDataAlter -= list =>
            {
                Debug.Log($"load data in view alter");
                //Instantiate objects and configure de contain in view
                showData.LoadData(list);
            };
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
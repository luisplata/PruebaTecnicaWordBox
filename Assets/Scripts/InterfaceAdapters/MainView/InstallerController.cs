using System;
using System.Collections.Generic;
using Domain;
using UniRx;
using UnityEngine;

namespace InterfaceAdapters.MainView
{
    public class InstallerController : IDisposable
    {
        private readonly InstallerViewModel _model;
        private readonly IRequestDataFromServer _request;
        private List<IDisposable> _disposables;

        public InstallerController(InstallerViewModel model, IRequestDataFromServer request)
        {
            _disposables = new List<IDisposable>();
            _model = model;
            _request = request;
            _model.loadDataFromWebSiteAlter += OnLoadDataFromWebSite;
        }

        private void OnLoadDataFromWebSite(string url)
        {
            Debug.Log($"Start request to {url}");
            _request.GetData(url).Forget();
        }

        public void Dispose()
        {
            _model.loadDataFromWebSiteAlter -= OnLoadDataFromWebSite;
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
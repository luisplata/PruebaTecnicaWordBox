using Cysharp.Threading.Tasks;
using Domain;

namespace InterfaceAdapters.MainView
{
    public interface IFinishedLoadDataFromServer
    {
        void LoadData(RandomUserData empty);
    }
}
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Domain
{
    public interface IRequestDataFromServer
    {
        UniTaskVoid GetData(string url);
    }
}
using System;
using Cysharp.Threading.Tasks;
using InterfaceAdapters.MainView;
using UnityEngine;
using UnityEngine.Networking;
using Utils;

namespace Domain
{
    public class RequestDataFromServer : IRequestDataFromServer
    {
        public async UniTaskVoid GetData(string url)
        {
            //Request with unitask ans response with a global event
            Debug.Log($"Before the send request");
            var response = (await UnityWebRequest.Get(url).SendWebRequest()).downloadHandler.text;
            Debug.Log(response);
            var randomUserData = JsonUtility.FromJson<RandomUserData>(response);
            ServiceLocator.Instance.GetService<IFinishedLoadDataFromServer>().LoadData(randomUserData);
        }
    }
}


public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
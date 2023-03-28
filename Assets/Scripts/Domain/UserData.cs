using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Domain
{
    public class UserData
    {
        private readonly Result _result;
        public Sprite foto;
        public string email;
        public string nombre;
        public string genero;
        public string edad;
        public string ciudad;
        public UserData(Result result)
        {
            _result = result;
            email = result.email;
            nombre = $"{result.name.title} {result.name.first} {result.name.last}";
            genero = result.gender;
            edad = $"{result.dob.age} years";
            ciudad = result.location.city;
            /*
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(result.picture.large);
            DownloadHandlerTexture handler = new DownloadHandlerTexture();
            request.downloadHandler = handler;

            // Use a coroutine to wait for the request to complete
            MainThreadDispatcher.StartCoroutine(LoadImageCoroutine(request));
            */
        }
        /*
        private IEnumerator LoadImageCoroutine(UnityWebRequest request)
        {
            Debug.Log($"Start to {Time.time}");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                foto = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            }
            else
            {
                Debug.LogError($"Failed to load image: {request.error}");
            }
            Debug.Log($"Finished to {Time.time}");
        }
        */

        public async UniTask LoadPicture()
        {
            Texture2D texture = await LoadTextureFromUrl(_result.picture.large);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            foto = sprite;
        }
        
        private async UniTask<Texture2D> LoadTextureFromUrl(string url)
        {
            using (var uwr = UnityWebRequestTexture.GetTexture(url))
            {
                var asyncOperation = uwr.SendWebRequest();
                while (!asyncOperation.isDone)
                {
                    await UniTask.Yield();
                }
                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    throw new System.Exception($"Failed to download texture from {url}: {uwr.error}");
                }
                return ((DownloadHandlerTexture)uwr.downloadHandler).texture;
            }
        }
    }
    [System.Serializable]
    public class RandomUserData
    {
        public Result[] results;
        public Info info;
    }

    [System.Serializable]
    public class Info
    {
        public string seed;
        public string results;
        public string page;
        public string version;
    }

    [System.Serializable]
    public class Result
    {
        public string gender;
        public Name name;
        public Location location;
        public string email;
        public Login login;
        public Dob dob;
        public Registered registered;
        public string phone;
        public string cell;
        public Id id;
        public Picture picture;
        public string nat;
    }

    [System.Serializable]
    public class Name
    {
        public string title;
        public string first;
        public string last;
    }

    [System.Serializable]
    public class Location
    {
        public Street street;
        public string city;
        public string state;
        public string country;
        public int postcode;
        public Coordinates coordinates;
        public Timezone timezone;
    }

    [System.Serializable]
    public class Street
    {
        public int number;
        public string name;
    }

    [System.Serializable]
    public class Coordinates
    {
        public string latitude;
        public string longitude;
    }

    [System.Serializable]
    public class Timezone
    {
        public string offset;
        public string description;
    }

    [System.Serializable]
    public class Login
    {
        public string uuid;
        public string username;
        public string password;
        public string salt;
        public string md5;
        public string sha1;
        public string sha256;
    }

    [System.Serializable]
    public class Dob
    {
        public string date;
        public int age;
    }

    [System.Serializable]
    public class Registered
    {
        public string date;
        public int age;
    }

    [System.Serializable]
    public class Id
    {
        public string name;
        public string value;
    }

    [System.Serializable]
    public class Picture
    {
        public string large;
        public string medium;
        public string thumbnail;
    }

}

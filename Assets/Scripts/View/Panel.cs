using Domain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] private Image picture;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private Button buttonToLike;
        public void Configure(UserData userData)
        {
            Debug.Log($"configure panel");
            picture.sprite = userData.foto;
            name.text = userData.nombre;
            buttonToLike.onClick.AddListener(() =>
            {
                //Show the big panel whit the data from configure
                ServiceLocator.Instance.GetService<IShowDataInBigPanel>().ShowData(userData);
            });
        }
    }
}
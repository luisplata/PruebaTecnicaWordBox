using System;
using Domain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View
{
    public class ShowDataInBigPanel : MonoBehaviour, IShowDataInBigPanel
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI name, genero, city, email, age;
        [SerializeField] private Image picture;

        public void ShowData(UserData userData)
        {
            name.text = userData.nombre;
            genero.text = userData.genero;
            city.text = userData.ciudad;
            email.text = userData.email;
            age.text = userData.edad;
            picture.sprite = userData.foto;
            animator.SetBool("open", true);
        }

        public void HideData()
        {
            animator.SetBool("open", false);
        }
    }
}
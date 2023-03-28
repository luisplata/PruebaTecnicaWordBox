using System.Collections.Generic;
using Domain;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ShowDataListInView : MonoBehaviour
    {
        [SerializeField] private Panel panelPrefab;
        [SerializeField] private GridLayoutGroup group;
        [SerializeField] private RectTransform container;
        [SerializeField] private GameObject panelToLoading;
        
        public void LoadData(List<UserData> data)
        {
            Debug.Log($"show data in list");
            foreach (var userData in data)
            {
                var panel = Instantiate(panelPrefab, group.transform);
                panel.Configure(userData);
            }
            
            //adding in button space with data size
            float numOfRows;
            numOfRows = data.Count / 3;

            var mod = data.Count % 3;
            Debug.Log($"num rows {numOfRows} from {data.Count} {mod}");
            
            numOfRows -= 2;

            if (mod > 0)
            {
                numOfRows++;
            }

            if (numOfRows > 0)
            {
                var addingToButtonSize = numOfRows * 430 * -1;
                container.offsetMin = new Vector2(container.offsetMax.x, addingToButtonSize);
            }
            panelToLoading.SetActive(false);
        }
    }
}
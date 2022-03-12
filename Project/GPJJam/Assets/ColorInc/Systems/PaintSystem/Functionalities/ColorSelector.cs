/*
 * Created by Leonardo Martin
 * Created 3/11/2022 6:04:22 PM
 */

using UnityEngine;
using UnityEngine.EventSystems;

namespace ColorInc.PaintSystem
{
    /// <summary>  
    /// Brief summary of what the class does
    /// </summary>
    public class ColorSelector : MonoBehaviour, IPointerClickHandler
    {
        [Header("Properties")] [Tooltip("Selector Color")] [SerializeField]
        private string color;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            var controller = GameObject.FindWithTag("GameController");
            controller.GetComponent<GameController>().SelectColor(color);
        }
    }
}
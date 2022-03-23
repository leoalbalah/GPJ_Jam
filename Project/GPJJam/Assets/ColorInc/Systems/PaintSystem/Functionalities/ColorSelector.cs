/*
 * Created by Leonardo Martin
 * Created 3/11/2022 6:04:22 PM
 */

using UnityEngine;
using UnityEngine.EventSystems;

namespace ColorInc.PaintSystem
{
    /// <summary>  
    /// Handles the UI interactions color selections.
    /// </summary>
    public class ColorSelector : MonoBehaviour, IPointerClickHandler
    {
        [Header("Properties")] 
        [SerializeField] private string color;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            var controller = GameObject.FindWithTag("GameController");
            controller.GetComponent<GameController>().SelectColor(color);
        }
    }
}
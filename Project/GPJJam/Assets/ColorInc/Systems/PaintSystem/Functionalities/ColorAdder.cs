/*
 * Created by Leonardo Martin
 * Created 3/11/2022 8:48:36 PM
 */

using UnityEngine;
using UnityEngine.EventSystems;

namespace ColorInc.PaintSystem
{
    /// <summary>  
    /// Handles the UI interactions for adding colors to the bucket.
    /// </summary>
    public class ColorAdder : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            var controller = GameObject.FindWithTag("GameController");
            controller.GetComponent<GameController>().ColorToBucket();
        }
    }
}
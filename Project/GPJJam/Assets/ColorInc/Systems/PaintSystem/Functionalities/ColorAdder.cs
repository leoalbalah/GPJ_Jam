/*
 * Created by Leonardo Martin
 * Created 3/11/2022 8:48:36 PM
 */

using UnityEngine;
using UnityEngine.EventSystems;

namespace ColorInc.PaintSystem
{
    /// <summary>  
    /// Brief summary of what the class does
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
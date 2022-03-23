/*
 * Created by Leonardo Martin
 * Created 3/11/2022 6:21:29 PM
 */

using UnityEngine;

namespace ColorInc.Player
{
    /// <summary>  
    /// Works in between the color selectors and the game logic.
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string selectedColor = "default";

        #endregion

        private void Start()
        {
            selectedColor = "default";
        }

        public void SetSelectedColor(string color)
        {
            selectedColor = color;
        }

        public string GetSelectedColor()
        {
            return selectedColor;
        }
    }
}
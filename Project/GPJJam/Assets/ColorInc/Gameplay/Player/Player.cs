/*
 * Created by Leonardo Martin
 * Created 3/11/2022 6:21:29 PM
 */

using System;
using UnityEngine;

namespace ColorInc.Player
{
    /// <summary>  
    /// Brief summary of what the class does
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
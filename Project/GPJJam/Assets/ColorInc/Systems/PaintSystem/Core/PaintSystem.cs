/*
 * Created by Leonardo Martin
 * Created 3/11/2022 8:33:58 PM
 */

using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorInc.PaintSystem
{
    /// <summary>  
    /// Brief summary of what the class does
    /// </summary>
    public class PaintSystem : MonoBehaviour
    {
        #region Properties

        [Header("Bucket")] [SerializeField] private GameObject bucket;

        [Header("Colors")] [Header("Default")] [SerializeField]
        private Sprite defaultTexture;

        [SerializeField] private Sprite blackTexture;

        [Header("Primary")] [SerializeField] private Sprite red;
        [SerializeField] private Sprite blue;
        [SerializeField] private Sprite yellow;
        [Header("Secondary")] [SerializeField] private Sprite purple;
        [SerializeField] private Sprite green;
        [SerializeField] private Sprite orange;
        [Header("Tertiary")] [SerializeField] private Sprite redOrange;
        [SerializeField] private Sprite yellowOrange;
        [SerializeField] private Sprite greenYellow;
        [SerializeField] private Sprite redPurple;
        [SerializeField] private Sprite blueGreen;
        [SerializeField] private Sprite bluePurple;

        #endregion

        #region Variables

        [Header("Debug")] [SerializeField] private Sprite activeTexture;
        [SerializeField] private string activeColor = "default";

        #endregion

        #region LifeCycle

        private void Start()
        {
            activeTexture = defaultTexture;
            UpdateTexture();
        }

        #endregion

        public void Colorize(string color)
        {
            if (color == "default") return;

            // Default Case
            if (activeColor == "default")
            {
                activeColor = color;

                switch (color)
                {
                    case "Red":
                        activeTexture = red;
                        break;
                    case "Blue":
                        activeTexture = blue;
                        break;
                    case "Yellow":
                        activeTexture = yellow;
                        break;
                }
            }

            // Primary Case
            else if (activeColor == "Red")
            {
                if (color == "Red") return;

                switch (color)
                {
                    case "Yellow":
                        activeColor = "Orange";
                        activeTexture = orange;
                        break;
                    case "Blue":
                        activeColor = "Purple";
                        activeTexture = purple;
                        break;
                }
            }

            else if (activeColor == "Blue")
            {
                if (color == "Blue") return;

                switch (color)
                {
                    case "Yellow":
                        activeColor = "Green";
                        activeTexture = green;
                        break;
                    case "Red":
                        activeColor = "Purple";
                        activeTexture = purple;
                        break;
                }
            }

            else if (activeColor == "Yellow")
            {
                if (color == "Yellow") return;

                switch (color)
                {
                    case "Blue":
                        activeColor = "Green";
                        activeTexture = green;
                        break;
                    case "Red":
                        activeColor = "Orange";
                        activeTexture = orange;
                        break;
                }
            }
            
            // Secondary
            else if (activeColor == "Orange")
            {
                switch (color)
                {
                    case "Red":
                        activeColor = "RedOrange";
                        activeTexture = redOrange;
                        break;
                    case "Yellow":
                        activeColor = "YellowOrange";
                        activeTexture = yellowOrange;
                        break;
                    case "Blue":
                        activeColor = "BlackTexture";
                        activeTexture = blackTexture;
                        break;
                }
            }

            else if (activeColor == "Green")
            {
                switch (color)
                {
                    case "Yellow":
                        activeColor = "GreenYellow";
                        activeTexture = greenYellow;
                        break;
                    case "Blue":
                        activeColor = "BlueGreen";
                        activeTexture = blueGreen;
                        break;
                    case "Red":
                        activeColor = "BlackTexture";
                        activeTexture = blackTexture;
                        break;
                }
            }

            else if (activeColor == "Purple")
            {
                switch (color)
                {
                    case "Blue":
                        activeColor = "BluePurple";
                        activeTexture = bluePurple;
                        break;
                    case "Red":
                        activeColor = "RedPurple";
                        activeTexture = redPurple;
                        break;
                    case "Yellow":
                        activeColor = "BlackTexture";
                        activeTexture = blackTexture;
                        break;
                }
            }

            UpdateTexture();
        }

        private void UpdateTexture()
        {
            Debug.Log("Updating");
            bucket.GetComponent<Image>().sprite = activeTexture;
        }

        public void Reset()
        {
            activeColor = "default";
            activeTexture = defaultTexture;
            UpdateTexture();
        }
    }
}
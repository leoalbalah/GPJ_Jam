/*
 * Created by Leonardo Martin
 * Created 3/11/2022 4:10:51 PM
 */

using UnityEngine;

namespace ColorInc.CusorSystem
{
    /// <summary>  
    /// Handles the cursor states, sprites and animations
    /// </summary>
    public class CursorSystem : MonoBehaviour
    {
        #region Properties

        [Header("Cursor Variants")] [Tooltip("Default")] [SerializeField]
        private Texture2D defaultSprite;

        [Tooltip("Yellow")] [SerializeField] private Texture2D yellowSprite;
        [Tooltip("Blue")] [SerializeField] private Texture2D blueSprite;
        [Tooltip("Red")] [SerializeField] private Texture2D redSprite;

        #endregion

        #region LifeCycle

        private void Start()
        {
            DoSetCursor(defaultSprite);
        }

        #endregion

        public void SetCursor(string color)
        {
            switch (color)
            {
                case "Red":
                    DoSetCursor(redSprite);
                    break;
                case "Yellow":
                    DoSetCursor(yellowSprite);
                    break;
                case "Blue":
                    DoSetCursor(blueSprite);
                    break;
                case "default":
                    DoSetCursor(defaultSprite);
                    break;
            }
        }

        private void DoSetCursor(Texture2D cursor)
        {
            Cursor.SetCursor(cursor,
                new Vector2(+cursor.width / 2, +cursor.height / 2),
                CursorMode.Auto);
        }
    }
}
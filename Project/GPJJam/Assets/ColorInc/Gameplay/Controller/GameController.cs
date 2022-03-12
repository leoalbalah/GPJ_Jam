/*
 * Created by Leonardo Martin
 * Created 3/11/2022 4:46:46 PM
 */

using ColorInc.CusorSystem;
using UnityEngine;

namespace ColorInc
{
    /// <summary>  
    /// Controls The Game Flow
    /// </summary>
    public class GameController : MonoBehaviour
    {
        #region Properties

        [Header("Imports")]
        [SerializeField] private Player.Player player;
        [SerializeField] private CursorSystem cursorSystem;
        [SerializeField] private PaintSystem.PaintSystem paintSystem;
        
        #endregion
        
        #region Variables

        private KeyBindings _keyBindings;

        #endregion
        
        #region LifeCycle

        private void OnEnable()
        {
            _keyBindings.Enable();
        }

        private void OnDisable()
        {
            _keyBindings.Disable();
        }

        private void Awake()
        {
            _keyBindings = new KeyBindings();
        }

        #endregion

        public void SelectColor(string color)
        {
            player.SetSelectedColor(color);
            cursorSystem.SetCursor(color);
        }

        public void ColorToBucket()
        {
            paintSystem.Colorize(player.GetSelectedColor());
            SelectColor("default");
        }

        public void BucketReseter()
        {
            paintSystem.Reset();
            SelectColor("default");
        }
    }
}
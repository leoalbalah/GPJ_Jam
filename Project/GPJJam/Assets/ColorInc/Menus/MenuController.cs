/*
 * Created by Leonardo Martin
 * Created 3/12/2022 5:04:13 PM
 */

using UnityEngine;

namespace ColorInc.UI
{
    /// <summary>  
    /// Controls The menus
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        #region Properties

        [Header("Properties")] [Tooltip("Pause Menu")] [SerializeField]
        private GameObject pauseMenu;

        #endregion

        #region LifeCycle

        private void Start()
        {
            pauseMenu.SetActive(false);
        }

        #endregion

        public void TogglePause()
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
}
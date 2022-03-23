/*
 * Created by Leonardo Martin
 * Created 3/12/2022 5:04:13 PM
 */

using TMPro;
using UnityEngine;

namespace ColorInc.UI
{
    /// <summary>  
    /// Controls the menus states.
    /// </summary>
    public class MenuController : MonoBehaviour
    {
        #region Properties

        [Header("Properties")] 
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject endGameMenu;
        [SerializeField] private GameObject uploadMenu;
        [SerializeField] private GameObject youMadeItPart;

        public TMP_InputField uploadInput;
        [SerializeField] private TextMeshProUGUI endGameScore;

        private int _score = 200;
        
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

        public void ToggleEndGame()
        {
            endGameScore.text = "Your Score : " + _score;
            endGameMenu.SetActive(!endGameMenu.activeSelf);
        }

        public void SetScore(int money)
        {
            _score = money;
        }

        public void ToggleUploadTab()
        {
            uploadMenu.SetActive(!uploadMenu.activeSelf);
        }

        public void SetYouMadeIt(bool set)
        {
            youMadeItPart.SetActive(set);
        }
    }
}
/*
 * Created by Leonardo Martin
 * Created 3/12/2022 6:04:01 PM
 */

using ColorInc.HighScore;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorInc.UI
{
    /// <summary>  
    /// Handles the Main menu interactions
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private HighScoreSystem highScore;
        
        public void ExitGame()
        {
            if (Application.isEditor)
            {
#if UNITY_EDITOR

                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else
            {
                Application.Quit();
            }
        }

        public void Play()
        {
            SceneManager.LoadScene("GameScene");
        }
        
        public void ToggleHighScore()
        {
            highScore.ToggleLeaderboard();
        }
    }
}
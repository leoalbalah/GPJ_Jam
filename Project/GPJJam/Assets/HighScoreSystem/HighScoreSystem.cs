/*
 * Created by Leonardo Martin
 * Created 3/12/2022 6:29:10 PM
 */

using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TMPro;
using UnityEngine;

namespace ColorInc.HighScore
{
    /// <summary>  
    /// Handles the HighScore Functionalities
    /// </summary>
    public class HighScoreSystem : MonoBehaviour
    {
        #region Properties

        [Header("Imports")] [SerializeField] private GameObject leaderboard;
        [SerializeField] private TextMeshProUGUI scoresText;

        #endregion

        #region Variables

        [SerializeField] private List<Score> highScores = new List<Score>();

        private const string PrivateCode = "x_6Q8xDQn0CWgwaM__b14QZPBITnHlh0uexsMgEFrHyQ";
        private const string PublicCode = "622d2bd68f40bc123c20d60c";
        private const string WebUrl = "http://dreamlo.com/lb/";

        #endregion

        private void Awake()
        {
            // AddNewHighScore("Testina", 250);
            DownloadHighScores();
        }

        public void AddNewHighScore(string username, int score)
        {
            StartCoroutine(UploadNewHighScore(username, score));
        }

        public void DownloadHighScores()
        {
            StartCoroutine(DownloadHighScoresCoroutine());
        }

        IEnumerator UploadNewHighScore(string username, int score)
        {
            var www = new WWW(WebUrl + PrivateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                Debug.Log("HighScore Uploaded");
            }
            else
            {
                Debug.LogError("HighScore Upload Error");
            }
        }

        IEnumerator DownloadHighScoresCoroutine()
        {
            var www = new WWW(WebUrl + PublicCode + "/json");
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                var items = JSON.Parse(www.text);
                var entries = items[0]["leaderboard"]["entry"];

                foreach (JSONNode entry in entries)
                {
                    highScores.Add(new Score(entry["name"], entry["score"]));
                }

                UpdateLeaderBoardUI();
            }
            else
            {
                Debug.LogError("HighScore Upload Error");
            }
        }

        private void UpdateLeaderBoardUI()
        {
            var lead = "";

            var pos = 1;
            foreach (var score in highScores)
            {
                lead += pos + ". " + score.User + " - " + score.Money + "\n";
                pos++;
            }

            scoresText.text = lead;
        }

        public void ToggleLeaderboard()
        {
            leaderboard.SetActive(!leaderboard.activeSelf);
        }
    }
}
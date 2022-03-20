/*
 * Created by Leonardo Martin
 * Created 3/11/2022 4:46:46 PM
 */

using System.Collections.Generic;
using ColorInc.CusorSystem;
using ColorInc.HighScore;
using ColorInc.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace ColorInc
{
    /// <summary>  
    /// Controls The Game Flow
    /// </summary>
    public class GameController : MonoBehaviour
    {
        #region Properties

        [Header("Imports")] [SerializeField] private Player.Player player;
        [SerializeField] private CursorSystem cursorSystem;
        [SerializeField] private PaintSystem.PaintSystem paintSystem;
        [SerializeField] private HUDSystem hudSystem;
        [SerializeField] private MenuController menuController;
        [SerializeField] private HighScoreSystem highScoreSystem;
        [SerializeField] private GameObject bubble;

        [SerializeField] private AudioSource bossSource;

        [SerializeField] private AudioClip randomBoss;


        [SerializeField] private AudioClip countDownSFX;

        [Header("Game Settings")] [SerializeField]
        private int sessionTime;

        [SerializeField] private int startMoney;
        [SerializeField] private int earnMoney;
        [SerializeField] private int spendMoney;

        [SerializeField] private string[] colors =
        {
            "Green", "Orange", "Purple", "RedOrange", "YellowOrange", "GreenYellow", "BlueGreen", "BluePurple",
            "RedPurple"
        };

        [SerializeField] private Dictionary<string, Color> colorDict = new Dictionary<string, Color>();

        [Header("Debug Game Goal")] [SerializeField]
        private string goalColor;

        #endregion

        #region Variables

        private KeyBindings _keyBindings;
        private int _money;
        private float _timeRemaining;
        private bool _timerIsRunning = false;
        private bool _paused = false;
        private AudioSource _audioSource;
        private bool _onCountDown = false;
        private bool playing = false;

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
            _audioSource = GetComponent<AudioSource>();
            _keyBindings = new KeyBindings();
        }

        private void Start()
        {
            InitDictionary();

            _keyBindings.Default.Pause.performed += _ => TogglePause();

            _timeRemaining = sessionTime;
            _timerIsRunning = true;

            _money = startMoney;
            hudSystem.Initialize(sessionTime, startMoney);

            GetGoal();
        }

        private void InitDictionary()
        {
            colorDict.Add("Green", ColorExtension.GetColorFromString("528a61"));
            colorDict.Add("Orange", ColorExtension.GetColorFromString("f39329"));
            colorDict.Add("Purple", ColorExtension.GetColorFromString("763455"));
            colorDict.Add("RedOrange", ColorExtension.GetColorFromString("eb5f32"));
            colorDict.Add("YellowOrange", ColorExtension.GetColorFromString("fcc30d"));
            colorDict.Add("GreenYellow", ColorExtension.GetColorFromString("b2b745"));
            colorDict.Add("BlueGreen", ColorExtension.GetColorFromString("137e93"));
            colorDict.Add("BluePurple", ColorExtension.GetColorFromString("4c5684"));
            colorDict.Add("RedPurple", ColorExtension.GetColorFromString("b12d44"));
        }

        private void Update()
        {
            Countdown();
        }

        #endregion

        private void Countdown()
        {
            if (!_timerIsRunning) return;
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;

                if (_timeRemaining <= 9 & !_onCountDown)
                {
                    _onCountDown = true;
                    _audioSource.clip = countDownSFX;
                    _audioSource.loop = false;
                    _audioSource.Play();
                }
            }
            else
            {
                _timeRemaining = 0;
                _timerIsRunning = false;
                menuController.SetYouMadeIt(highScoreSystem.GetAvailability(_money));
                menuController.SetScore(_money);
                menuController.ToggleEndGame();
                paintSystem.gameObject.SetActive(false);
            }

            float minutes = Mathf.FloorToInt(_timeRemaining / 60);
            float seconds = Mathf.FloorToInt(_timeRemaining % 60);

            hudSystem.UpdateTime($"{minutes:00}:{seconds:00}");
        }

        public void SelectColor(string color)
        {
            if (!_timerIsRunning) return;

            player.SetSelectedColor(color);
            cursorSystem.SetCursor(color);
        }

        public void ColorToBucket()
        {
            if (!_timerIsRunning) return;

            // Paint
            paintSystem.Colorize(player.GetSelectedColor());
            SelectColor("default");

            // Spend
            _money -= spendMoney;
            hudSystem.Spend(spendMoney);

            // Check Completion
            if (paintSystem.GetBucketColor() == goalColor)
            {
                _money += earnMoney;
                hudSystem.Earn(earnMoney);

                LeanTween.delayedCall(.5f, () =>
                {
                    paintSystem.Reset();
                    SelectColor("default");
                });

                GetGoal();
            }
        }

        public void BucketReseter()
        {
            if (!_timerIsRunning) return;

            bubble.SetActive(true);

            if (!playing)
            {
                playing = true;
                bossSource.PlayOneShot(randomBoss);
                LeanTween.delayedCall(3.8f, () =>
                {
                    bubble.SetActive(false);
                    playing = false;
                });
            }

            paintSystem.Reset();
            SelectColor("default");
        }

        private void GetGoal()
        {
            var lastGoal = goalColor;

            var newGoal = colors[Random.Range(0, colors.Length)];
            while (newGoal == lastGoal)
            {
                newGoal = colors[Random.Range(0, colors.Length)];
            }

            goalColor = newGoal;
            hudSystem.SetGoal(colorDict[goalColor]);
        }

        public void TogglePause()
        {
            _paused = !_paused;
            menuController.TogglePause();
            Time.timeScale = _paused ? 0f : 1f;
        }

        public void ExitGame()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void RetryGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void ShowUploadTab()
        {
            menuController.ToggleEndGame();
            menuController.ToggleUploadTab();
        }

        public void UploadScore()
        {
            if (string.IsNullOrEmpty(menuController.uploadInput.text)) return;

            highScoreSystem.AddNewHighScore(menuController.uploadInput.text, _money);
            menuController.SetYouMadeIt(false);

            ShowUploadTab();
        }
    }
}
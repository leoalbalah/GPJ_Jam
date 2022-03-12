/*
 * Created by Leonardo Martin
 * Created 3/11/2022 4:46:46 PM
 */

using ColorInc.CusorSystem;
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

        [Header("Debug Game Goal")] [SerializeField]
        private string goalColor;

        #endregion

        #region Variables

        private KeyBindings _keyBindings;
        private int _money;
        private float _timeRemaining;
        private bool _timerIsRunning = false;
        private bool _paused = false;

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

        private void Start()
        {
            _keyBindings.Default.Pause.performed += _ => TogglePause();

            _timeRemaining = sessionTime;
            _timerIsRunning = true;

            _money = startMoney;
            hudSystem.Initialize(sessionTime, startMoney);

            GetGoal();
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
            }
            else
            {
                Debug.Log("Time has run out!");
                _timeRemaining = 0;
                _timerIsRunning = false;
            }

            float minutes = Mathf.FloorToInt(_timeRemaining / 60);
            float seconds = Mathf.FloorToInt(_timeRemaining % 60);

            hudSystem.UpdateTime(string.Format("{0:00}:{1:00}", minutes, seconds));
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

                LeanTween.delayedCall(.5f, () => { BucketReseter(); });

                GetGoal();
            }
        }

        public void BucketReseter()
        {
            if (!_timerIsRunning) return;

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
            hudSystem.SetGoal(goalColor);
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
    }
}
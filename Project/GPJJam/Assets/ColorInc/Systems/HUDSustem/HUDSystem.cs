/*
 * Created by Leonardo Martin
 * Created 3/12/2022 2:45:08 PM
 */

using System;
using TMPro;
using UnityEngine;

namespace ColorInc.UI
{
    /// <summary>  
    /// Brief summary of what the class does
    /// </summary>
    public class HUDSystem : MonoBehaviour
    {
        #region Properties

        [Header("Imports")] 
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private SpriteRenderer goalTvColor;

        [Header("Sounds")] [SerializeField] private AudioClip moneyEarn;

        #endregion

        #region Variables

        private int _money = 200;

        #endregion

        public void Spend(int amount)
        {
            _money -= amount;
            UpdateUI();
        }

        public void Earn(int amount)
        {
            _money += amount;
            GetComponent<AudioSource>().PlayOneShot(moneyEarn);
            UpdateUI();
        }

        private void UpdateUI()
        {
            moneyText.text = _money.ToString() + " $";
        }

        public void Initialize(int sessionTime, int startMoney)
        {
            _money = startMoney;
            UpdateUI();
        }

        public void SetGoal(Color goal)
        {
            goalTvColor.color = goal;
        }

        public void UpdateTime(string timeLeft)
        {
            timerText.text = timeLeft;
        }
    }
}
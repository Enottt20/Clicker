using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins;

        public static Action OnCoinsChanged;

        private void Start()
        {
            UpdateUi();
        }
        
        private void UpdateUi()
        {
            _coins.text = "Coins: " + Currency.Coins;
        }

        private void OnEnable()
        {
            OnCoinsChanged = UpdateUi;
        }

        private void OnDisable()
        {
            OnCoinsChanged = null;
        }
    }
}
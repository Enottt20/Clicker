using UnityEngine;

namespace Assets.Scripts
{
    public static class Currency
    {
        public const string CoinsString = "Coins";
        
        public static int Coins
        {
            get => PlayerPrefs.GetInt(CoinsString);

            private set => PlayerPrefs.SetInt(CoinsString, value);
        }

        public static void SubtractCoins(int value)
        {
            if (value <= Coins)
            {
                Coins -= value;
                CurrencyView.OnCoinsChanged?.Invoke();
            }
            else
            {
                Debug.LogError("Не хватает денег");
            }
            
        }
        
        public static void AppendCoins(int value)
        {
            Coins += value;
            CurrencyView.OnCoinsChanged?.Invoke();
        }
    }
}
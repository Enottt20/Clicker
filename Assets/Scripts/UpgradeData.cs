using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class UpgradeData
    {
        [SerializeField] private int _price;

        [SerializeField] private float _incomeMultiplier;
        
        public int Price { get => _price; }
        
        public float IncomeMultiplier { get => _incomeMultiplier; }
        
        public bool Purchased { get; set; }
    }
}
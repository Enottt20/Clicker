using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class BusinessData : Data
    {
        private SavedData _savedData;
        
        [SerializeField] private float _incomeDelay;

        [SerializeField] private float _basePrice;

        [SerializeField] private float _baseIncome;

        [SerializeField] private int _baseLevel;

        [SerializeField] private UpgradeData _firstUpgradeData;

        [SerializeField] private UpgradeData _secondUpgradeData;
        
        private int _level;
        
        private float _currentIncomeDelay;


        #region Properties

        public float IncomeDelay { get => _incomeDelay; }
    
        public float BasePrice { get => _basePrice; }
    
        public float BaseIncome { get => _baseIncome; }
        
        public int BaseLevel { get => _baseLevel; }
    
        public UpgradeData FirstUpgradeConfig { get => _firstUpgradeData; }
    
        public UpgradeData SecondUpgradeConfig { get => _secondUpgradeData; }
        
        public bool Purchased { get; set; }

        public int Level { get => _level; set => _level = value; }

        public float CurrentIncomeDelay { get => _currentIncomeDelay; set => _currentIncomeDelay = value; }

        #endregion

        public BusinessData(int id) : base(id)
        {
        }

        public void Save()
        {
            _savedData = new SavedData();
            
            _savedData.level = Level;
            _savedData.currentIncomeDelay = CurrentIncomeDelay;
            _savedData.firstUpgradePurchased = FirstUpgradeConfig.Purchased;
            _savedData.secondUpgradePurchased = SecondUpgradeConfig.Purchased;
            
            string saveJson = JsonUtility.ToJson(_savedData);
            PlayerPrefs.SetString($"Save{_id}", saveJson);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey($"Save{_id}"))
            {
                string saveJson = PlayerPrefs.GetString($"Save{_id}");
                _savedData = JsonUtility.FromJson<SavedData>(saveJson);

                Level = _savedData.level;
                CurrentIncomeDelay = _savedData.currentIncomeDelay;
                FirstUpgradeConfig.Purchased = _savedData.firstUpgradePurchased;
                SecondUpgradeConfig.Purchased = _savedData.secondUpgradePurchased;
            }
        }

        [System.Serializable]
        private class SavedData
        {
            public int level;
            public float currentIncomeDelay;
            public bool firstUpgradePurchased;
            public bool secondUpgradePurchased;
        }
    }
}
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class BusinessInfo : Data
    {
        [SerializeField] private string _name;

        [SerializeField] private UpgradeInfo _firstUpgradeInfo;
        
        [SerializeField] private UpgradeInfo _secondUpgradeInfo;
        
        public UpgradeInfo FirstUpgradeInfo { get => _firstUpgradeInfo; }
        
        public UpgradeInfo SecondUpgradeInfo { get => _secondUpgradeInfo; }
        
        public string Name { get => _name; }

        public BusinessInfo(Data lastData, int id) : base(id)
        {
        }
    }
}
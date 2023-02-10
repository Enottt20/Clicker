using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class UpgradeInfo
    {
        [SerializeField] private string _name;
        
        public string Name { get => _name; }
    }
}
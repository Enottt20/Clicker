namespace Assets.Scripts
{
    public class Upgrade
    {
        private UpgradeData _upgradeData;

        public Upgrade(UpgradeData upgradeData)
        {
            _upgradeData = upgradeData;
        }
        
        public float Income()
        {
            if (!_upgradeData.Purchased) return 0;
            
            var income = _upgradeData.IncomeMultiplier;
            return income;
        } 
    }
}
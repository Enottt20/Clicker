using UnityEngine;

namespace Assets.Scripts
{
    public class Business
    {
        public BusinessData BusinessData { get; }
        public BusinessInfo BusinessInfo { get; }

        public Business(int id)
        {
            BusinessData = Resources.Load<BusinessConfig>("BusinessConfig").GetElement(id);
            BusinessInfo = Resources.Load<BusinessInfoConfig>("BusinessInfoConfig").GetElement(id);
            
            BusinessData.Load();

            if (BusinessData.Level < BusinessData.BaseLevel) 
                BusinessData.Level = BusinessData.BaseLevel;

            if (BusinessData.Level > 0)
                BusinessData.Purchased = true;

        }

        public void Tick()
        {
            if(!BusinessData.Purchased) return;
            
            BusinessData.CurrentIncomeDelay += Time.deltaTime;

            if (BusinessData.CurrentIncomeDelay >= BusinessData.IncomeDelay)
            {
                BusinessData.CurrentIncomeDelay = 0;
                Currency.AppendCoins((int)Income());
            }
        }

        public void PurchaseUpgrade(UpgradeData upgradeData)
        {
            if(Currency.Coins < upgradeData.Price || upgradeData.Purchased) return;
            
            Currency.SubtractCoins(upgradeData.Price);
            upgradeData.Purchased = true;
        }

        public void PurchaseNewLevel()
        {
            if(Currency.Coins < CurrentPrice()) return;
            
            Currency.SubtractCoins((int)CurrentPrice());
            BusinessData.Level++;
            BusinessData.Purchased = true;
        }

        public int CurrentPrice()
        {
            var price = (BusinessData.Level + 1) * BusinessData.BasePrice;
            return (int)price;
        }

        public int Income()
        {
            var income = BusinessData.Level * BusinessData.BaseIncome * (1 
                + new Upgrade(BusinessData.FirstUpgradeConfig).Income() 
                + new Upgrade(BusinessData.SecondUpgradeConfig).Income());
            
            return (int)income;
        }
    }
}
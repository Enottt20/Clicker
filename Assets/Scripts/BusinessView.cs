using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BusinessView : MonoBehaviour
    {
        [SerializeField] private int _businessId;
        [SerializeField] private Image _incomeBar;
        
        [Space]
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI income;
        [SerializeField] private TextMeshProUGUI price;

        [Space]
        [SerializeField] private Button levelUpBtn;
        [SerializeField] private Button firstUpgradeBtn;
        [SerializeField] private Button secondUpgradeBtn;
        
        [Space]
        [SerializeField] private TextMeshProUGUI firstUpgradeBtnTitle;
        [SerializeField] private TextMeshProUGUI secondUpgradeBtnTitle;
        
        [Space]
        [SerializeField] private TextMeshProUGUI firstUpgradeBtnIncome;
        [SerializeField] private TextMeshProUGUI secondUpgradeBtnIncome;
        
        [Space]
        [SerializeField] private TextMeshProUGUI firstUpgradeBtnPrice;
        [SerializeField] private TextMeshProUGUI secondUpgradeBtnPrice;
        
        private Business _business;

        private void Start()
        {
            _business = new Business(_businessId);
            
            UpdateUi();
            ButtonsInit();
        }
        
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                _business.BusinessData.Save();
            }
        }
        
        private void OnApplicationQuit()
        {
            _business.BusinessData.Save();
        }

        private void FixedUpdate()
        {
            _business.Tick();
            
            _incomeBar.fillAmount = _business.BusinessData.CurrentIncomeDelay / _business.BusinessData.IncomeDelay;
        }

        private void ButtonsInit()
        {
            levelUpBtn.onClick.AddListener((() =>
            {
                _business.PurchaseNewLevel();
                UpdateUi();
            }));
            
            firstUpgradeBtn.onClick.AddListener((() =>
            {
                _business.PurchaseUpgrade(_business.BusinessData.FirstUpgradeConfig);
                UpdateUi();
            }));
            
            secondUpgradeBtn.onClick.AddListener((() =>
            {
                _business.PurchaseUpgrade(_business.BusinessData.SecondUpgradeConfig);
                UpdateUi();
            }));
        }

        private void UpdateUi()
        {
            title.text = _business.BusinessInfo.Name;
            level.text = _business.BusinessData.Level + " LVL";
            income.text = $"Income: {_business.Income()}";
            price.text = _business.CurrentPrice().ToString();
            //

            firstUpgradeBtnTitle.text = _business.BusinessInfo.FirstUpgradeInfo.Name;
            secondUpgradeBtnTitle.text = _business.BusinessInfo.SecondUpgradeInfo.Name;

            var firstUpIncome = _business.BusinessData.FirstUpgradeConfig.IncomeMultiplier * 100;
            
            firstUpgradeBtnIncome.text = $"Income: + {firstUpIncome}%";
            
            var secondtUpIncome = _business.BusinessData.SecondUpgradeConfig.IncomeMultiplier * 100;
            
            secondUpgradeBtnIncome.text = $"Income: + {secondtUpIncome}%";

            if (_business.BusinessData.FirstUpgradeConfig.Purchased) 
                firstUpgradeBtnPrice.text = "Purchased";
            else 
                firstUpgradeBtnPrice.text = $"Price: {_business.BusinessData.FirstUpgradeConfig.Price}";
            
            if (_business.BusinessData.SecondUpgradeConfig.Purchased) 
                secondUpgradeBtnPrice.text = "Purchased";
            else 
                secondUpgradeBtnPrice.text = $"Price: {_business.BusinessData.SecondUpgradeConfig.Price}";
            
            
                //secondUpgradeBtnPrice.text =  $"Price: {_business.BusinessData.SecondUpgradeConfig.Price}";
        }
    }
}
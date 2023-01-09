using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.BuisnessLogic;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.ViewModels.BuisnessLogicViewModel
{
    public class ProductBViewModel : WorkspaceViewModel
    {
        #region Properties

        public ProductsB ProductB { get; set; }

        private decimal _AllProductsAmount;
        public decimal AllProductsAmount
        {
            get
            {
                return _AllProductsAmount;
            }
            set
            {
                if (_AllProductsAmount != value)
                {
                    _AllProductsAmount = value;
                    OnPropertyChanged(() => AllProductsAmount);
                }
            }
        }
        private decimal _MostExpensive;
        public decimal MostExpensive
        {
            get
            {
                return _MostExpensive;
            }
            set
            {
                if (_MostExpensive != value)
                {
                    _MostExpensive = value;
                    OnPropertyChanged(() => MostExpensive);
                }
            }
        }
        private decimal _BestDiscount;
        public decimal BestDiscount
        {
            get
            {
                return _BestDiscount;
            }
            set
            {
                if (_BestDiscount != value)
                {
                    _BestDiscount = value;
                    OnPropertyChanged(() => BestDiscount);
                }
            }
        }
        
        private decimal _StoreMost;
        public decimal StoreMost
        {
            get
            {
                return _StoreMost;
            }
            set
            {
                if (_StoreMost != value)
                {
                    _StoreMost = value;
                    OnPropertyChanged(() => StoreMost);
                }
            }
        }
        
        private string _BestSeller;
        public string BestSeller
        {
            get
            {
                return _BestSeller;
            }
            set
            {
                if (_BestSeller != value)
                {
                    _BestSeller = value;
                    OnPropertyChanged(() => BestSeller);
                }
                
            }
        }

        private DateTime _LatestAdded;
        public DateTime LatestAdded
        {
            get
            {
                return _LatestAdded;
            }
            set
            {
                if (_LatestAdded != value)
                {
                    _LatestAdded = value;
                    OnPropertyChanged(() => LatestAdded);
                }
            }
        }
        #endregion

        #region Constructor
        public ProductBViewModel()
        {
            base.DisplayName = "Product Report";
            KjsCompany2Entities2 db = new KjsCompany2Entities2();
            ProductB = new ProductsB(db);
            AllProductsAmount = ProductB.GetAllProductAmount();
            MostExpensive = ProductB.GetMostExpensiveProduct();
            BestDiscount = ProductB.GetBestDiscount();
            StoreMost = ProductB.GetStoreTheMost();
            BestSeller = ProductB.GetBestSeller();
            LatestAdded = ProductB.GetLatestAdded();
        }
        #endregion
    }
}

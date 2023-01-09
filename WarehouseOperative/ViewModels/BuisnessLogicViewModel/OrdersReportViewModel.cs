using System;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.BuisnessLogic;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.ViewModels.BuisnessLogicViewModel
{
    public class OrdersReportViewModel : WorkspaceViewModel
    {
        #region Properties

        public OrdersB OrderB { get; set; }
        public DateTime DateFrom
        {
            get
            {
                return OrderB.DateFrom;
            }
            set
            {
                if(OrderB.DateFrom != value)
                {
                    OrderB.DateFrom = value;
                    OnPropertyChanged(() => DateFrom);
                }
            }
        }
        public DateTime DateTo
        {
            get
            {
                return OrderB.DateTo;
            }
            set
            {
                if (OrderB.DateTo != value)
                {
                    OrderB.DateTo = value;
                    OnPropertyChanged(() => DateTo);
                }
            }
        }
        private decimal _Profit;
        public decimal Profit
        {
            get
            {
                return _Profit;
            }
            set
            {
                if (value != _Profit)
                {
                    _Profit = value;
                    OnPropertyChanged(() => Profit);
                }
            }
        }
        private string _Type;
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (value != _Type)
                {
                    _Type = value;
                    OnPropertyChanged(() => Type);
                }
            }
        }
        private decimal _Items;
        public decimal Items
        {
            get
            {
                return _Items;
            }
            set
            {
                if (value != _Items)
                {
                    _Items = value;
                    OnPropertyChanged(() => Items);
                }
            }
        }
        private DateTime _ItemsSoldDate;
        public DateTime ItemsSoldDate
        {
            get
            {
                return _ItemsSoldDate;
            }
            set
            {
                if (_ItemsSoldDate != value)
                {
                    _ItemsSoldDate = value;
                    OnPropertyChanged(() => ItemsSoldDate);
                }
            }
        }
        #endregion

        #region Commands

        private ICommand _OrderProfitCommand;
        public ICommand OrderProfitCommand
        {
            get
            {
                if (_OrderProfitCommand == null)
                {
                    _OrderProfitCommand = new BaseCommand(() => CountProfit());
                }
                return _OrderProfitCommand;
            }
        }
        private ICommand _MostItemsSoldDateCommand;
        public ICommand MostItemsSoldDateCommand
        {
            get
            {
                if (_MostItemsSoldDateCommand == null)
                {
                    _MostItemsSoldDateCommand = new BaseCommand(() => MostItemsSoldDateC());
                }
                return _MostItemsSoldDateCommand;
            }
        }

        private ICommand _MostItemsSoldCommand;
        public ICommand MostItemsSoldCommand
        {
            get
            {
                if (_MostItemsSoldCommand == null)
                {
                    _MostItemsSoldCommand = new BaseCommand(() => ItemsSold());
                }
                return _MostItemsSoldCommand;
            }
        }
        #endregion

        #region Constructor
        public OrdersReportViewModel()
        {
            base.DisplayName = "Order Report";
            KjsCompany2Entities2 db = new KjsCompany2Entities2();
            OrderB = new OrdersB(db);
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            Type = "Szt";
        }
        #endregion

        #region Methods

        private void CountProfit()
        {
            Profit = OrderB.Profit();
        }

        private void MostItemsSoldDateC()
        {
            ItemsSoldDate = OrderB.MostItemsSold();
        }

        private void ItemsSold()
        {
            Items = OrderB.ItemsSold();
        }
        #endregion
    }
}

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

        #endregion

        #region Constructor
        public OrdersReportViewModel()
        {
            base.DisplayName = "Order Report";
            KjsCompany2Entities2 db = new KjsCompany2Entities2();
            OrderB = new OrdersB(db);
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
        }
        #endregion

        #region Methods

        private void CountProfit()
        {
            Profit = OrderB.Profit();
        }

        #endregion
    }
}

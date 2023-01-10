using System;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.BuisnessLogic;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.ViewModels.BuisnessLogicViewModel
{
    public class CustomerBViewModel : WorkspaceViewModel
    {
        #region Properties

        public CustomersB CustomerB { get; set; }
        public DateTime DateFrom
        {
            get
            {
                return CustomerB.DateFrom;
            }
            set
            {
                if (CustomerB.DateFrom != value)
                {
                    CustomerB.DateFrom = value;
                    OnPropertyChanged(() => DateFrom);
                }
            }
        }
        public DateTime DateTo
        {
            get
            {
                return CustomerB.DateTo;
            }
            set
            {
                if (CustomerB.DateTo != value)
                {
                    CustomerB.DateTo = value;
                    OnPropertyChanged(() => DateTo);
                }
            }
        }

        private string _MostPayableCustomer;
        public string MostPayableCustomer
        {
            get
            {
                return _MostPayableCustomer;
            }
            set
            {
                if (_MostPayableCustomer != value)
                {
                    _MostPayableCustomer = value;
                    OnPropertyChanged(() => MostPayableCustomer);
                }
            }
        }

        private int _AllCustomers;
        public int AllCustomers
        {
            get
            {
                return _AllCustomers;
            }
            set
            {
                if(_AllCustomers != value)
                {
                    _AllCustomers = value;
                    OnPropertyChanged(() => AllCustomers);
                }
            }
        }

        private string _FirstCustomer;
        public string FirstCustomer
        {
            get
            {
                return _FirstCustomer;
            }
            set
            {
                if (_FirstCustomer != value)
                {
                    _FirstCustomer = value;
                    OnPropertyChanged(() => FirstCustomer);
                }
            }
        }
        private string _LastCustomer;
        public string LastCustomer
        {
            get
            {
                return _LastCustomer;
            }
            set
            {
                if (_LastCustomer != value)
                {
                    _LastCustomer = value;
                    OnPropertyChanged(() => LastCustomer);
                }
            }
        }

        #endregion

        #region Constructor
        public CustomerBViewModel()
        {
            base.DisplayName = "Customer Report";
            KjsCompany2Entities2 db = new KjsCompany2Entities2();
            CustomerB = new CustomersB(db);
            DateFrom = DateTime.Now;
            DateTo = DateTime.Now;
            FirstCustomer = CustomerB.GetFirstCustomer();
            LastCustomer = CustomerB.GetLastCustomer();
        }
        #endregion

        #region Commands

        private ICommand _AllCustomersCommand;
        public ICommand AllCustomersCommand
        {
            get
            {
                if (_AllCustomersCommand == null)
                {
                    _AllCustomersCommand = new BaseCommand(() => GetAllCustomers());
                }
                return _AllCustomersCommand;
            }
        }


        private ICommand _MostPayableCustomerCommand;
        public ICommand MostPayableCustomerCommand
        {
            get
            {
                if (_MostPayableCustomerCommand == null)
                {
                    _MostPayableCustomerCommand = new BaseCommand(() => GetMostPayableCustomer());
                }
                return _MostPayableCustomerCommand;
            }
        }

        #endregion

        #region Methods

        private void GetMostPayableCustomer()
        {
            MostPayableCustomer = CustomerB.GetMostPayCustomer();
        }

        private void GetAllCustomers()
        {
            AllCustomers = CustomerB.GetCustomersAmount();
        }

        #endregion
    }
}
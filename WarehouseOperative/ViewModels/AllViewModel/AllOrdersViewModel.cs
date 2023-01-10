using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class AllOrdersViewModel : AllViewModel<OrdersForAllView>
    {
        #region Properties
        
        private OrdersForAllView _ChoosenOrder;
        public OrdersForAllView ChoosenOrder
        {
            get
            {
                return _ChoosenOrder;
            }
            set
            {
                if (_ChoosenOrder != value)
                {
                    _ChoosenOrder = value;
                    OnPropertyChanged(() => ChoosenOrder);
                    if (_ChoosenOrder != null)
                    {
                        MessageBox.Show($"Choosen Order\nCustomer Name:  {ChoosenOrder.CustomersCustomerName}, Product Name:  {ChoosenOrder.ProductsProductName}, Order Id: ({ChoosenOrder.OrderId})", "Status");
                        Messenger.Default.Send(_ChoosenOrder);
                        OnRequestClose();
                    }
                }
            }
        }

        #endregion

        #region Konstruktor
        public AllOrdersViewModel()
            : base("All Orders")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            try
            {
                AllList = (
                    from orders in WarehouseEntities.OrdersPositions
                    where orders.IsActive == true
                    select new OrdersForAllView
                    {
                        OrderId = orders.Orders.Id,
                        CustomersCustomerName = orders.Orders.Customers.CompanyName,
                        ProductsProductName = orders.Products.ProductName,
                        OrderQuantity = orders.Quantity,
                        ProductsUnitPrice = orders.Price,
                        CreationDate = orders.Orders.CreationDate,
                        ShipperName = orders.Orders.Shippers.CompanyName,
                        EmployeeName = orders.Orders.Employees.LastName,
                        PricePaid = orders.Orders.PricePaid
                    }).ToList();
                List = new ObservableCollection<OrdersForAllView>(AllList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Order Id":
                    List = new ObservableCollection<OrdersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.OrderId) :
                        List.OrderBy(item => item.OrderId));
                    break;
                case "Customer Name":
                    List = new ObservableCollection<OrdersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.CustomersCustomerName) :
                        List.OrderBy(item => item.CustomersCustomerName));
                    break;
                case "Order Quantity":
                    List = new ObservableCollection<OrdersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.OrderQuantity) :
                        List.OrderBy(item => item.OrderQuantity));
                    break;
                case "Price Paid":
                    List = new ObservableCollection<OrdersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.PricePaid) :
                        List.OrderBy(item => item.PricePaid));
                    break;
                case "Unit Price":
                    List = new ObservableCollection<OrdersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.ProductsUnitPrice) :
                        List.OrderBy(item => item.ProductsUnitPrice));
                    break;
            }
        }

        protected override void Search()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("Search box is empty!", "Status");
                return;
            }
            switch (SearchField)
            {
                case "Customer Name":
                    List = new ObservableCollection<OrdersForAllView>(AllList.Where(item => item.CustomersCustomerName.ToLower().Trim() == SearchText));
                    break;
                case "Order Quantity":
                    List = new ObservableCollection<OrdersForAllView>(AllList.Where(item => item.OrderQuantity.ToString().Trim() == SearchText));
                    break;
                case "Unit Price":
                    List = new ObservableCollection<OrdersForAllView>(AllList.Where(item => item.ProductsUnitPrice.ToString().Trim() == SearchText));
                    break;
            }
        }

        protected override List<string> GetSortComboBoxItems()
        {
            return new List<string>()
            {
                "Order Id",
                "Customer Name",
                "Order Quantity",
                "Price Paid",
                "Unit Price"
            };
        }

        protected override List<string> GetSearchComboBoxItems()
        {
            return new List<string>()
            {
                "Customer Name",
                "Order Quantity",
                "Unit Price"
            };
        }

        #endregion
    }
}

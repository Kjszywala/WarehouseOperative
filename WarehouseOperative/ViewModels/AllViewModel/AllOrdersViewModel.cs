using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class AllOrdersViewModel : AllViewModel<OrdersForAllView>
    {
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
                List = new ObservableCollection<OrdersForAllView>(
                    from orders in WarehouseEntities.OrdersPositions
                    where orders.IsActive == true
                    select new OrdersForAllView
                    {
                        OrderId = orders.Id,
                        CustomersCustomerName = orders.Orders.Customers.CompanyName,
                        ProductsProductName = orders.Products.ProductName,
                        OrderQuantity = orders.Quantity,
                        ProductsUnitPrice = orders.Price,
                        CreationDate = orders.Orders.CreationDate,
                        ShipperName = orders.Orders.Shippers.CompanyName,
                        EmployeeName = orders.Orders.Employees.LastName ,
                        PricePaid = orders.Orders.PricePaid
                    }
                );
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}

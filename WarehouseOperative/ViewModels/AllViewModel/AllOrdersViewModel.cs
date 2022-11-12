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
                    from orders in WarehouseEntities.Orders
                    where orders.IsActive == true
                    select new OrdersForAllView
                    {
                        OrderId = orders.Order_Id,
                        CustomersCustomerName = orders.Customers.CompanyName,
                        ProductsProductName = orders.Products.ProductName,
                        OrderQuantity = orders.OrderQuantity,
                        ProductsUnitPrice = orders.Products.UnitPrice,
                        CustomersPricePaid = orders.Customers.PricePaid,
                        OrderDate = orders.OrderDate,
                        RequiredDate = orders.RequiredDate,
                        ShippedDate = orders.ShippedDate,
                        ShippersShipperCompanyName = orders.Shippers.CompanyName,
                        SuppliersCompanyName = orders.Products.Suppliers.CompanyName,
                        CategoriesDescription = orders.Products.Categories.Description,
                        LastChangedDateTime = orders.LastChangedDataTime
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

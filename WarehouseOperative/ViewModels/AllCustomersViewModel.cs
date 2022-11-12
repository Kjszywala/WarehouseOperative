using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.ViewModels.Abstract;
using WarehouseOperative.Models.EntitiesForView;

namespace WarehouseOperative.ViewModels
{
    public class AllCustomersViewModel : AllViewModel<CustomersForAllView>
    {
        #region Konstruktor
        public AllCustomersViewModel()
            : base("Customers")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            try
            {
                List = new ObservableCollection<CustomersForAllView>(
                    from customer in WarehouseEntities.Customers
                    where customer.IsActive == true
                    select new CustomersForAllView
                    {
                        CustomerId = customer.Customer_Id,
                        CompanyName = customer.CompanyName,
                        PricePaid = customer.PricePaid,
                        HouseNumber = customer.CustomerAddress.HouseNumber,
                        StreetName = customer.CustomerAddress.StreetName,
                        City = customer.CustomerAddress.City,
                        Country = customer.CustomerAddress.Country
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

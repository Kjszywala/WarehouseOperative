using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.ViewModels.Abstract;
using WarehouseOperative.Models.EntitiesForView;

namespace WarehouseOperative.ViewModels.AllViewModel
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
                        CustomerId = customer.Id,
                        CompanyName = customer.CompanyName,
                        FirstName = customer.FirstName,
                        SecondName = customer.SecondName,
                        HouseNumber = customer.CustomerAddresses.HouseNumber,
                        StreetName = customer.CustomerAddresses.StreetName,
                        PostCode = customer.CustomerAddresses.PostCode,
                        City = customer.CustomerAddresses.City,
                        Country = customer.CustomerAddresses.Country
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

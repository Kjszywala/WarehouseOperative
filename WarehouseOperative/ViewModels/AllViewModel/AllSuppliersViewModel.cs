using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class AllSuppliersViewModel : AllViewModel<SuppliersForAllView>
    {
        #region Konstruktor
        public AllSuppliersViewModel()
            : base("Suppliers")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            try
            {
                List = new ObservableCollection<SuppliersForAllView>(
                    from supliers in WarehouseEntities.Suppliers
                    select new SuppliersForAllView
                    {
                        SupplierId = supliers.Id,
                        CompanyName = supliers.CompanyName,
                        ContactName = supliers.ContactName,
                        SuplierAddressPostcode = supliers.SupplierAddresses.PostCode,
                        SuplierAddressCity = supliers.SupplierAddresses.City,
                        SuplierAddressCountry = supliers.SupplierAddresses.Country,
                        SuplierAddressPhone = supliers.SupplierAddresses.Phone,
                        SuplierAddressFax = supliers.SupplierAddresses.Fax
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

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.Entities;
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
                        SupplierId = supliers.Supplier_Id,
                        CompanyName = supliers.CompanyName,
                        ContactName = supliers.ContactName,
                        SuplierAddressStreetName = supliers.SupplierAddress.StreetName,
                        SuplierAddressPostcode = supliers.SupplierAddress.PostCode,
                        SuplierAddressCity = supliers.SupplierAddress.City,
                        SuplierAddressCountry = supliers.SupplierAddress.Country,
                        SuplierAddressPhone = supliers.SupplierAddress.Phone,
                        SuplierAddressFax = supliers.SupplierAddress.Fax
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

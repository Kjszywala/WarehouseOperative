using System;
using System.Collections.Generic;
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
                AllList = (
                    from supliers in WarehouseEntities.Suppliers
                    select new SuppliersForAllView
                    {
                        Id = supliers.Id,
                        CompanyName = supliers.CompanyName,
                        ContactName = supliers.ContactName,
                        SuplierAddressStreetName = supliers.SupplierAddresses.StreetName,
                        SuplierAddressPostcode = supliers.SupplierAddresses.PostCode,
                        SuplierAddressCity = supliers.SupplierAddresses.City,
                        SuplierAddressCountry = supliers.SupplierAddresses.Country,
                        SuplierAddressPhone = supliers.SupplierAddresses.Phone,
                        SuplierAddressFax = supliers.SupplierAddresses.Fax,
                        SupplierAddressHomePage = supliers.SupplierAddresses.HomePage
                    }).ToList();
                List = new ObservableCollection<SuppliersForAllView>(AllList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        protected override List<string> GetSearchComboBoxItems()
        {
            return new List<string>()
            {
                "Company Name",
                "Contact Name",
                "Suplier Address Country",
                "Suplier Address City",
            };
        }

        protected override List<string> GetSortComboBoxItems()
        {
            return new List<string>()
            {
                "Company Name",
                "Contact Name",
                "Suplier Address Country",
                "Suplier Address City",
            };
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
                case "Company Name":
                    List = new ObservableCollection<SuppliersForAllView>(AllList.Where(item => item.CompanyName.ToLower().Trim() == SearchText));
                    break;
                case "Contact Name":
                    List = new ObservableCollection<SuppliersForAllView>(AllList.Where(item => item.ContactName.ToString().Trim() == SearchText));
                    break;
                case "Suplier Address Country":
                    List = new ObservableCollection<SuppliersForAllView>(AllList.Where(item => item.SuplierAddressCountry.ToString().Trim() == SearchText));
                    break;
                case "Suplier Address City":
                    List = new ObservableCollection<SuppliersForAllView>(AllList.Where(item => item.SuplierAddressCity.ToString().Trim() == SearchText));
                    break;
            }
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Company Name":
                    List = new ObservableCollection<SuppliersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.CompanyName) :
                        List.OrderBy(item => item.CompanyName));
                    break;
                case "Contact Name":
                    List = new ObservableCollection<SuppliersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.ContactName) :
                        List.OrderBy(item => item.ContactName));
                    break;
                case "Suplier Address Country":
                    List = new ObservableCollection<SuppliersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.SuplierAddressCountry) :
                        List.OrderBy(item => item.SuplierAddressCountry));
                    break;
                case "Suplier Address City":
                    List = new ObservableCollection<SuppliersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.SuplierAddressCity) :
                        List.OrderBy(item => item.SuplierAddressCity));
                    break;
            }
        }
        #endregion
    }
}

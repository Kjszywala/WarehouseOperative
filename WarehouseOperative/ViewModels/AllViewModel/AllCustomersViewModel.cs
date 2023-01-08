using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.ViewModels.Abstract;
using WarehouseOperative.Models.EntitiesForView;
using System.Collections.Generic;

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
                AllList = (
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
                    }).ToList();
                List = new ObservableCollection<CustomersForAllView>(AllList);
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
                "First Name",
                "Second Name",
                "Customer Address Id",
                "Phone Number"
            };
        }

        protected override List<string> GetSortComboBoxItems()
        {
            return new List<string>()
            {
                "Company Name",
                "First Name",
                "Second Name",
                "Customer Address Id",
                "Phone Number",
                "Customer Id"
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
                case "First Name":
                    List = new ObservableCollection<CustomersForAllView>(AllList.Where(item => item.FirstName.ToLower().Trim() == SearchText));
                    break;
                case "Customer Address Id":
                    List = new ObservableCollection<CustomersForAllView>(AllList.Where(item => item.HouseNumber.ToLower().Trim() == SearchText));
                    break;
                case "Second Name":
                    List = new ObservableCollection<CustomersForAllView>(AllList.Where(item => item.SecondName.ToLower().Trim() == SearchText));
                    break;
                case "Phone Number":
                    List = new ObservableCollection<CustomersForAllView>(AllList.Where(item => item.PhoneNumber.ToLower().Trim() == SearchText));
                    break;
            }
        }
        
        protected override void Sort()
        {
            switch (SortField)
            {
                case "Company Name":
                    List = new ObservableCollection<CustomersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.CompanyName) :
                        List.OrderBy(item => item.CompanyName));
                    break;
                case "First Name":
                    List = new ObservableCollection<CustomersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.FirstName) :
                        List.OrderBy(item => item.FirstName));
                    break;
                case "Customer Address Id":
                    List = new ObservableCollection<CustomersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.HouseNumber) :
                        List.OrderBy(item => item.HouseNumber));
                    break;
                case "Second Name":
                    List = new ObservableCollection<CustomersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.SecondName) :
                        List.OrderBy(item => item.SecondName));
                    break;
                case "Phone Number":
                    List = new ObservableCollection<CustomersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.PhoneNumber) :
                        List.OrderBy(item => item.PhoneNumber));
                    break;
                case "Customer Id":
                    List = new ObservableCollection<CustomersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.CustomerId) :
                        List.OrderBy(item => item.CustomerId));
                    break;
            }
        }
        #endregion
    }
}

using System.Collections.ObjectModel;
using System.Windows;
using System;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;
using System.Linq;
using System.Collections.Generic;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class AllEmloyeesViewModel : AllViewModel<EmployeeForAllView>
    {
        #region Konstruktor
        public AllEmloyeesViewModel()
            : base("All Employes")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            try
            {
                AllList = (
                        from employee in WarehouseEntities.Employees
                        where employee.IsActive == true
                        select new EmployeeForAllView
                        {
                            EmployeeID = employee.Id,
                            EmployeeFirstName = employee.FirstName,
                            EmployeeLastName = employee.LastName,
                            Email = employee.Email,
                            Phone = employee.Phone,
                            HireDate = employee.HireDate,
                            JobTitle = employee.JobTitle,
                            FlatNumber = employee.EmployeeAddresses.Flatnumber,
                            StreetName = employee.EmployeeAddresses.StreetName,
                            PostCode = employee.EmployeeAddresses.PostCode,
                            City = employee.EmployeeAddresses.City,
                            Country = employee.EmployeeAddresses.Country
                        }).ToList();

                List = new ObservableCollection<EmployeeForAllView>(AllList);
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
                "Phone"
            };
        }

        protected override List<string> GetSortComboBoxItems()
        {
            return new List<string>()
            {
                "First Name",
                "Second Name",
                "Phone",
                "Hire Date"
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
                    List = new ObservableCollection<EmployeeForAllView>(AllList.Where(item => item.EmployeeFirstName.ToLower().Trim() == SearchText));
                    break;
                case "Second Name":
                    List = new ObservableCollection<EmployeeForAllView>(AllList.Where(item => item.EmployeeLastName.ToLower().Trim() == SearchText));
                    break;
                case "Phone":
                    List = new ObservableCollection<EmployeeForAllView>(AllList.Where(item => item.Phone.ToLower().Trim() == SearchText));
                    break;
            }
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "First Name":
                    List = new ObservableCollection<EmployeeForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.EmployeeFirstName) :
                        List.OrderBy(item => item.EmployeeFirstName));
                    break;
                case "Second Name":
                    List = new ObservableCollection<EmployeeForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.EmployeeLastName) :
                        List.OrderBy(item => item.EmployeeLastName));
                    break;
                case "Phone":
                    List = new ObservableCollection<EmployeeForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.Phone) :
                        List.OrderBy(item => item.Phone));
                    break;
                case "Hire Date":
                    List = new ObservableCollection<EmployeeForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.HireDate) :
                        List.OrderBy(item => item.HireDate));
                    break;
            }
        }
        #endregion
    }
}

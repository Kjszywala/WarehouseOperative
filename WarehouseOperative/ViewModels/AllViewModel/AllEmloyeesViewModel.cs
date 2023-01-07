using System.Collections.ObjectModel;
using System.Windows;
using System;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;
using System.Linq;

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
                List = new ObservableCollection<EmployeeForAllView>(
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

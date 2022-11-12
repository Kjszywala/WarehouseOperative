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
                        from employee in WarehouseEntities.EmployeeTable
                        where employee.IsActive == true
                        select new EmployeeForAllView
                        {
                            EmployeeID = employee.Employee_Id,
                            EmployeeFirstName = employee.FirstName,
                            EmployeeLastName = employee.LastName,
                            Email = employee.Email,
                            Phone = employee.Phone,
                            HireDate = employee.Hire_Date,
                            JobTitle = employee.Job_Title,
                            EmployeeAddress =
                                employee.EmployeeAddress.StreetName + ", " +
                                employee.EmployeeAddress.PostCode,
                            EmployeeAnualLeaveDaysLeft =
                                employee.EmploeesAnnualLeave.DaysLeft
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

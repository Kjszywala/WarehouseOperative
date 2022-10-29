using System.Collections.ObjectModel;
using System.Windows;
using System;
using WarehouseOperative.Models.Entities;
using WarehouseOperative.ViewModels.Abstract;
using System.Linq;

namespace WarehouseOperative.ViewModels
{
    public class AllEmloyeesViewModel : AllViewModel<Employees>
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
                //To jest zapytanie LINQ (obiektowa wersja SQL)
                List = new ObservableCollection<Employees>(
                        //dla kazdego towaru z tabeli towar wybierz ten towar.
                        //SELECT * FROM Towar
                        //WHERE CzyAktywny = true
                        from employee in WarehouseEntities.Employees
                        where employee.IsActive == true
                        select employee
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

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.Entities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels
{
    public class ErrorLogViewModel : AllViewModel<ErrorLog>
    {
        #region Konstruktor
        public ErrorLogViewModel()
            : base("Error Log")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            try
            {
                //To jest zapytanie LINQ (obiektowa wersja SQL)
                List = new ObservableCollection<ErrorLog>(
                        //dla kazdego towaru z tabeli towar wybierz ten towar.
                        //SELECT * FROM Towar
                        from errorLog in KjsCompanyEntities1.ErrorLog
                        select errorLog
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

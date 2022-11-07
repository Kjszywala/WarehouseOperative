using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.Entities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels
{
    public class AllInvoicesViewModel : AllViewModel<Invoices>
    {
        #region Konstruktor
        public AllInvoicesViewModel()
            : base("All Invoices")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            try
            {
                //To jest zapytanie LINQ (obiektowa wersja SQL)
                List = new ObservableCollection<Invoices>(
                        //dla kazdego towaru z tabeli towar wybierz ten towar.
                        //SELECT * FROM Towar
                        //WHERE CzyAktywny = true
                        from invoices in WarehouseEntities.Invoices
                        where invoices.isActive == true
                        select invoices
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

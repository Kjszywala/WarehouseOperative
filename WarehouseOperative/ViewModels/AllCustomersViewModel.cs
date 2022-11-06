using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.ViewModels.Abstract;
using WarehouseOperative.Models.Entities;

namespace WarehouseOperative.ViewModels
{
    public class AllCustomersViewModel : AllViewModel<Customers>
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
                //To jest zapytanie LINQ (obiektowa wersja SQL)
                List = new ObservableCollection<Customers>(
                        //dla kazdego towaru z tabeli towar wybierz ten towar.
                        //SELECT * FROM Towar
                        //WHERE CzyAktywny = true
                        from customer in KjsCompanyEntities1.Customers
                        where customer.IsActive == true
                        select customer
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

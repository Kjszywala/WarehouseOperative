﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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
                        from customer in FakturyEntities.Customers
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

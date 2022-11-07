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
                List = new ObservableCollection<Customers>(
                        from customer in WarehouseEntities.Customers
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

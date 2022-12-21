using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class AllShippersViewModel : AllViewModel<ShippersForAllView>
    {
        #region Konstruktor
        public AllShippersViewModel()
            : base("Shippers")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            try
            {
                List = new ObservableCollection<ShippersForAllView>(
                    from shippers in WarehouseEntities.Shippers
                    select new ShippersForAllView
                    {
                        CompanyName = shippers.CompanyName,
                        Phone = shippers.Phone
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

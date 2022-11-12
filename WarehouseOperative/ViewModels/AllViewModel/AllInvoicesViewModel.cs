using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.Entities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
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
                List = new ObservableCollection<Invoices>(
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

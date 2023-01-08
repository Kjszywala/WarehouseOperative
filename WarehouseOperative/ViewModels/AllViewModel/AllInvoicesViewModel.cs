using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class AllInvoicesViewModel : AllViewModel<InvoicesForAllView>
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
                List = new ObservableCollection<InvoicesForAllView>(
                        from invoices in WarehouseEntities.Invoices
                        where invoices.IsActive == true
                        select new InvoicesForAllView()
                        {
                            InvoiceId = invoices.Id,
                            CreationDate = invoices.CreationDate,
                            ModificationDate = invoices.ModificationDate,
                            InvoiceNumber = invoices.InvoiceNumber,
                            OrderId = invoices.Orders.Id,
                            PaymentMethod = invoices.PaymentMethods.Title,
                            IsConfirmed = invoices.IsConfirmed
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

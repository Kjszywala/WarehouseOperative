using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
                AllList = (from invoices in WarehouseEntities.Invoices
                         where invoices.IsActive == true
                         select new InvoicesForAllView()
                         {
                             InvoiceId = invoices.Id,
                             Title = invoices.Title,
                             CreationDate = invoices.CreationDate,
                             ModificationDate = invoices.ModificationDate,
                             InvoiceNumber = invoices.InvoiceNumber,
                             OrderId = invoices.Orders.Id,
                             PaymentMethod = invoices.PaymentMethods.Title,
                             IsConfirmed = invoices.IsConfirmed
                         }).ToList();

                List = new ObservableCollection<InvoicesForAllView>(AllList);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        protected override List<string> GetSearchComboBoxItems()
        {
            return new List<string>()
            {
                "Number",
                "Id"
            };
        }

        protected override List<string> GetSortComboBoxItems()
        {
            return new List<string>()
            {
                "Number",
                "Id",
                "Order Id",
                "Title",
                "Creation Date",
                "Modification Date",
                "Payment Method"
            };
        }

        protected override void Search()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("Search box is empty!","Status");
                return;
            }
            switch (SearchField)
            {
                case "Number":
                    List = new ObservableCollection<InvoicesForAllView>(AllList.Where(item => item.InvoiceNumber.ToLower().Trim() == SearchText));
                    break;
                case "Id":
                    List = new ObservableCollection<InvoicesForAllView>(AllList.Where(item => item.InvoiceId.ToString().Trim() == SearchText));
                    break;
            }
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Number":
                    List = new ObservableCollection<InvoicesForAllView>(SortDescending ? 
                        List.OrderByDescending(item => item.InvoiceNumber) : 
                        List.OrderBy(item => item.InvoiceNumber));
                    break;
                case "Id":
                    List = new ObservableCollection<InvoicesForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.InvoiceId) :
                        List.OrderBy(item => item.InvoiceId));
                    break;
                case "Order Id":
                    List = new ObservableCollection<InvoicesForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.OrderId) :
                        List.OrderBy(item => item.OrderId));
                    break;
                case "Title":
                    List = new ObservableCollection<InvoicesForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.Title) :
                        List.OrderBy(item => item.Title));
                    break;
                case "Creation Date":
                    List = new ObservableCollection<InvoicesForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.CreationDate) :
                        List.OrderBy(item => item.CreationDate));
                    break;
                case "Modification Date":
                    List = new ObservableCollection<InvoicesForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.ModificationDate) :
                        List.OrderBy(item => item.ModificationDate));
                    break;
                case "Payment Method":
                    List = new ObservableCollection<InvoicesForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.PaymentMethod) :
                        List.OrderBy(item => item.PaymentMethod));
                    break;
            }
        }

        #endregion
    }
}

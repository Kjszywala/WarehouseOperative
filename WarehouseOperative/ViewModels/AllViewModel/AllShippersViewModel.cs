using System;
using System.Collections.Generic;
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
                AllList = (
                    from shippers in WarehouseEntities.Shippers
                    select new ShippersForAllView
                    {
                        CompanyName = shippers.CompanyName,
                        Phone = shippers.Phone
                    }).ToList();
                List = new ObservableCollection<ShippersForAllView>(AllList);
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
                "Company Name"
            };
        }

        protected override List<string> GetSortComboBoxItems()
        {
            return new List<string>()
            {
                "Company Name",
                "Phone"
            };
        }

        protected override void Search()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("Search box is empty!", "Status");
                return;
            }
            switch (SearchField)
            {
                case "Company Name":
                    List = new ObservableCollection<ShippersForAllView>(AllList.Where(item => item.CompanyName.ToLower().Trim() == SearchText));
                    break;
                case "Phone":
                    List = new ObservableCollection<ShippersForAllView>(AllList.Where(item => item.Phone.ToString().Trim() == SearchText));
                    break;
            }
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Company Name":
                    List = new ObservableCollection<ShippersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.CompanyName) :
                        List.OrderBy(item => item.CompanyName));
                    break;
                case "Phone":
                    List = new ObservableCollection<ShippersForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.Phone) :
                        List.OrderBy(item => item.Phone));
                    break;
            }
        }
        #endregion
    }
}

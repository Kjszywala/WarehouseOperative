using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.EntitiesForView;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.AllViewModel
{
    public class ErrorLogViewModel : AllViewModel<ErrorLogForAllView>
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
                List = new ObservableCollection<ErrorLogForAllView>(
                        from errorLog in WarehouseEntities.ErrorLogs
                        select new ErrorLogForAllView
                        {
                            Id = errorLog.Id,
                            Title = errorLog.Title,
                            Description = errorLog.Descript
                        }
                    );
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
                "Description",
                "Id",
                "Title"
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
                case "Description":
                    List = new ObservableCollection<ErrorLogForAllView>(AllList.Where(item => item.Description.ToLower().Trim().Contains(SearchText)));
                    break;
            }
        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Description":
                    List = new ObservableCollection<ErrorLogForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.Description) :
                        List.OrderBy(item => item.Description));
                    break;
                case "Id":
                    List = new ObservableCollection<ErrorLogForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.Id) :
                        List.OrderBy(item => item.Id));
                    break;
                case "Title":
                    List = new ObservableCollection<ErrorLogForAllView>(SortDescending ?
                        List.OrderByDescending(item => item.Title) :
                        List.OrderBy(item => item.Title));
                    break;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WarehouseOperative.Models.Entities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels
{
    public class ErrorLogViewModel : AllViewModel<ErrorLog>
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
                List = new ObservableCollection<ErrorLog>(
                        from errorLog in WarehouseEntities.ErrorLog
                        select errorLog
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.Entities;

namespace WarehouseOperative.ViewModels.Abstract
{
    public abstract class AddRowViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //tu jest cala baza danych.
        public WarehouseEntities Db { get; set; }
        //tu jest nasz dodawany towar.
        public T Item { get; set; }
        #endregion

        #region Konstruktor
        public AddRowViewModel(string displayName)
        {
            base.DisplayName = displayName;
            Db = new WarehouseEntities();
        }
        #endregion

        #region Commands
        // to jest commenda ktoraa zostanie podpieta (zbindowana) z przyciskiem
        // zapisz i zamknij. Komenda ta wywola funkcje saveAndClose.
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }
        #endregion

        #region Save
        public abstract void Save();

        private void saveAndClose()
        {
            //Zapisuje towar.
            Save();
            //zamyka zakladke.
            base.OnRequestClose();
        }
        #endregion
    }
}

﻿using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.ViewModels.Abstract
{
    public abstract class AddRowViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //Database variable
        public KjsCompany2Entities2 Db { get; set; }
        //Adding bookmark with new (product,invoice etc.)
        public T Item { get; set; }
        #endregion

        #region Konstruktor
        public AddRowViewModel(string displayName)
        {
            base.DisplayName = displayName;
            Db = new KjsCompany2Entities2();
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command which will be connected to Save and close button.
        /// </summary>
        private ICommand _SaveAndCloseCommand;
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

        public new ICommand CloseCommand
        {
            get
            {
                return new BaseCommand(closeCommand);
            }
        }

        #endregion

        #region Save

        public abstract void Save();

        private void saveAndClose()
        {
            //Save product.
            Save();
            //Close bookmark.
            base.OnRequestClose();
        }
        #endregion

        #region Helpers
        private void closeCommand()
        {
            base.OnRequestClose();
        }

        #endregion
    }
}

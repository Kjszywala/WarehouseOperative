using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Input;
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
        /// <summary>
        /// Command for sending messages.
        /// </summary>
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    // pusta wywoluje load.
                    _AddCommand = new BaseCommand(() => Add());
                }
                return _AddCommand;
            }
        }
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

        /// <summary>
        /// Abstract method for all bookmarks to add row to db.
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// Saving to db and closing the bookmark
        /// </summary>
        private void saveAndClose()
        {
            //Save product.
            Save();
            //Close bookmark.
            base.OnRequestClose();
            MessageBox.Show("Successfully saved to database.", "Confirmation");
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Sending the message to CreateView method in MainWindowViewModel.
        /// </summary>
        public void Add()
        {
            Messenger.Default.Send("Add " + DisplayName);
        }
        /// <summary>
        /// Closing the bookmark.
        /// </summary>
        private void closeCommand()
        {
            base.OnRequestClose();
        }

        #endregion
    }
}

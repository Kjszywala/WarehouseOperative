using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.ViewModels.Abstract
{
    public abstract class AllViewModel<T>: WorkspaceViewModel
    {
        #region Fields
        // Database connection.
        public readonly KjsCompany2Entities2 warehouseEntities;
        public KjsCompany2Entities2 WarehouseEntities
        {
            get
            {
                return warehouseEntities;
            }
        }
        //Load product command.
        private ICommand _loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    // if emty then load.
                    _loadCommand = new BaseCommand(() => Load());
                }
                return _loadCommand;
            }
        }
        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => Add());
                }
                return _AddCommand;
            }
        }
        // All products here.
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                // if list is emty then load.
                if (_List == null)
                {
                    Load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        #endregion

        #region Konstruktor
        public AllViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.warehouseEntities = new KjsCompany2Entities2();
        }
        #endregion

        #region Helpers
        public abstract void Load();

        public void Add()
        {
            Messenger.Default.Send("Show " + DisplayName);
        }
        #endregion
    }
}

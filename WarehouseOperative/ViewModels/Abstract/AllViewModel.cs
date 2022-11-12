using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.Entities;

namespace WarehouseOperative.ViewModels.Abstract
{
    public abstract class AllViewModel<T>: WorkspaceViewModel
    {
        #region Fields
        // Database connection.
        public readonly WareEntities warehouseEntities;
        public WareEntities WarehouseEntities
        {
            get
            {
                return warehouseEntities;
            }
        }
        //Load product command.
        private BaseCommand _loadCommand;
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
            this.warehouseEntities = new WareEntities();
        }
        #endregion

        #region Helpers
        public abstract void Load();

        #endregion
    }
}

using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.DatabaseEntities;

namespace WarehouseOperative.ViewModels.Abstract
{
    public abstract class AllViewModel<T>: WorkspaceViewModel
    {
        #region Properties

        // Database connection.
        public readonly KjsCompany2Entities2 warehouseEntities;
        public KjsCompany2Entities2 WarehouseEntities
        {
            get
            {
                return warehouseEntities;
            }
        }
        public List<T> AllList { get; set; }
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
        public List<string> SortComboBoxItems { get; set; }
        public List<string> SearchComboBoxItems { get; set; }
        private string _SortField;
        public string SortField
        {
            get
            {
                return _SortField;
            }
            set
            {
                if(_SortField != value)
                {
                    _SortField = value;
                    OnPropertyChanged(() => SortField);
                }
            }
        }
        private string _SearchField;
        public string SearchField
        {
            get
            {
                return _SearchField;
            }
            set
            {
                if (_SearchField != value)
                {
                    _SearchField = value;
                    OnPropertyChanged(() => SearchField);
                }
            }
        }
        private string _SearchText;
        public string SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                if (_SearchText != value)
                {
                    _SearchText = value.ToLower().Trim();
                    OnPropertyChanged(() => SearchText);
                }
            }
        }
        private bool _SortDescending;
        public bool SortDescending
        {
            get
            {
                return _SortDescending;
            }
            set
            {
                if (_SortDescending != value)
                {
                    _SortDescending = value;
                    OnPropertyChanged(() => SortDescending);
                }
            }
        }

        #endregion

        #region Commands

        private ICommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if(_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }

        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new BaseCommand(() => Search());
                }
                return _SearchCommand;
            }
        }

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

        #endregion

        #region Konstruktor

        public AllViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.warehouseEntities = new KjsCompany2Entities2();
            SortComboBoxItems = GetSortComboBoxItems();
            SearchComboBoxItems = GetSearchComboBoxItems();
        }

        #endregion

        #region Helpers

        abstract protected void Sort();
        abstract protected void Search();
        abstract protected List<string> GetSortComboBoxItems();
        abstract protected List<string> GetSearchComboBoxItems();
        public abstract void Load();
        public void Add()
        {
            Messenger.Default.Send("Show " + DisplayName);
        }

        #endregion
    }
}

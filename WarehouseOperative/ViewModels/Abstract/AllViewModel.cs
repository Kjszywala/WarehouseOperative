using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseOperative.Helpers;
using WarehouseOperative.Models.Entities;

namespace WarehouseOperative.ViewModels.Abstract
{
    public abstract class AllViewModel<T>: WorkspaceViewModel
    {
        #region Fields
        // To jest obiekt ktory bedzie sluzyl do operacji na bazie danych.
        public readonly WarehouseEntities warehouseEntities;
        public WarehouseEntities WarehouseEntities
        {
            get
            {
                return warehouseEntities;
            }
        }
        //to jest komenda do zaladowania towarow.
        private BaseCommand _loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    // pusta wywoluje load.
                    _loadCommand = new BaseCommand(() => Load());
                }
                return _loadCommand;
            }
        }
        // w tym obiekcie beda wszystkie towary.
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                // jak lista pusta wywolujemy load.
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
            this.warehouseEntities = new WarehouseEntities();
        }
        #endregion

        #region Helpers
        public abstract void Load();
        #endregion
    }
}

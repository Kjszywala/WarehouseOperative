using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewSupplierViewModel : AddRowViewModel<Suppliers>, IDataErrorInfo
    {
        #region Constructor

        public NewSupplierViewModel()
            : base("Supplier")
        {
            Item = new Suppliers()
            {
                IsActive = true
            };
            Messenger.Default.Register<SupplierAddresses>(this, GetSupplierAddress);
        }
        #endregion

        #region Properties

        public string CompanyName
        {
            get
            {
                return Item.CompanyName;
            }
            set
            {
                if (value != Item.CompanyName)
                {
                    Item.CompanyName = value;
                    OnPropertyChanged(() => CompanyName);
                }
            }
        }
        public string ContactName
        {
            get
            {
                return Item.ContactName;
            }
            set
            {
                if (value != Item.ContactName)
                {
                    Item.ContactName = value;
                    OnPropertyChanged(() => ContactName);
                }
            }
        }
        public string ContactTitle
        {
            get
            {
                return Item.ContactTitle;
            }
            set
            {
                if (value != Item.ContactTitle)
                {
                    Item.ContactTitle = value;
                    OnPropertyChanged(() => ContactTitle);
                }
            }
        }
        public int? SuplierAddressId
        {
            get
            {
                return Item.SupplierAddressId;
            }
            set
            {
                if (value != Item.SupplierAddressId)
                {
                    Item.SupplierAddressId = value;
                    OnPropertyChanged(() => SuplierAddressId);
                }
            }
        }
        private string _SupplierAddress;
        public string SupplierAddress
        {
            get
            {
                return _SupplierAddress;
            }
            set
            {
                if (value != _SupplierAddress)
                {
                    _SupplierAddress = value;
                    OnPropertyChanged(() => SupplierAddress);
                }
            }
        }
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CompanyName):
                        return StringValidator.IsLenghtCorrect(CompanyName, 255);
                    case nameof(ContactName):
                        return StringValidator.IsLenghtCorrect(ContactName, 20);
                    case nameof(ContactTitle):
                        return StringValidator.IsLenghtCorrect(ContactTitle, 50);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Methods
        protected override bool IsValid()
        {
            return this[nameof(CompanyName)] == string.Empty
                && this[nameof(ContactName)] == string.Empty
                && this[nameof(ContactTitle)] == string.Empty;
        }

        private void GetSupplierAddress(SupplierAddresses address)
        {
            SupplierAddress = $"Choosen addrees: {address.StreetName}, {address.PostCode}, {address.City}";
            SuplierAddressId = address.Id;
        }
        public override void Save()
        {
            try
            {
                Db.Suppliers.AddObject(Item);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}

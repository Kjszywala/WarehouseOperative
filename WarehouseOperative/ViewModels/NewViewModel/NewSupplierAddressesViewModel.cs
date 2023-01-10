using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewSupplierAddressesViewModel: AddRowViewModel<SupplierAddresses>, IDataErrorInfo
    {
        #region Constructor

        public NewSupplierAddressesViewModel()
            : base("SupplierAddress")
        {
            Item = new SupplierAddresses();
        }
        #endregion

        #region Properties

        public string StreetName
        {
            get
            {
                return Item.StreetName;
            }
            set
            {
                if (value != Item.StreetName)
                {
                    Item.StreetName = value;
                    OnPropertyChanged(() => StreetName);
                }
            }
        }
        public string PostCode
        {
            get
            {
                return Item.PostCode;
            }
            set
            {
                if (value != Item.PostCode)
                {
                    Item.PostCode = value;
                    OnPropertyChanged(() => PostCode);
                }
            }
        }
        public string City
        {
            get
            {
                return Item.City;
            }
            set
            {
                if (value != Item.City)
                {
                    Item.City = value;
                    OnPropertyChanged(() => City);
                }
            }
        }
        public string Country
        {
            get
            {
                return Item.Country;
            }
            set
            {
                if (value != Item.Country)
                {
                    Item.Country = value;
                    OnPropertyChanged(() => Country);
                }
            }
        }
        public string Phone
        {
            get
            {
                return Item.Phone;
            }
            set
            {
                if (value != Item.Phone)
                {
                    Item.Phone = value;
                    OnPropertyChanged(() => Phone);
                }
            }
        }
        public string Fax
        {
            get
            {
                return Item.Fax;
            }
            set
            {
                if (value != Item.Fax)
                {
                    Item.Fax = value;
                    OnPropertyChanged(() => Fax);
                }
            }
        }
        public string HomePage
        {
            get
            {
                return Item.HomePage;
            }
            set
            {
                if (value != Item.HomePage)
                {
                    Item.HomePage = value;
                    OnPropertyChanged(() => HomePage);
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
                    case nameof(StreetName):
                        return StringValidator.IsLenghtCorrect(StreetName, 255);
                    case nameof(PostCode):
                        return StringValidator.IsLenghtCorrect(PostCode, 20);
                    case nameof(City):
                        return StringValidator.IsLenghtCorrect(City, 50);
                    case nameof(Country):
                        return StringValidator.IsLenghtCorrect(Country, 50);
                    case nameof(Phone):
                        return StringValidator.IsLenghtCorrect(Phone, 50);
                    case nameof(Fax):
                        return StringValidator.IsLenghtCorrect(Fax, 50);
                    case nameof(HomePage):
                        return StringValidator.IsLenghtCorrect(HomePage, 50);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Save
        protected override bool IsValid()
        {
            return this[nameof(StreetName)] == string.Empty
                && this[nameof(PostCode)] == string.Empty
                && this[nameof(City)] == string.Empty
                && this[nameof(Country)] == string.Empty
                && this[nameof(Phone)] == string.Empty
                && this[nameof(Fax)] == string.Empty
                && this[nameof(HomePage)] == string.Empty;
        }

        public override void Save()
        {
            try
            {
                Db.SupplierAddresses.AddObject(Item);
                Db.SaveChanges();
                Messenger.Default.Send(Item);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}

using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewCustomerAddressesViewModel : AddRowViewModel<CustomerAddresses>, IDataErrorInfo
    {
        #region Properties

        public string HouseNumber
        {
            get
            {
                return Item.HouseNumber;
            }
            set
            {
                if (value != Item.HouseNumber)
                {
                    Item.HouseNumber = value;
                    OnPropertyChanged(() => HouseNumber);
                }
            }
        }
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
        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(HouseNumber):
                        return StringValidator.IsLenghtCorrect(HouseNumber, 255);
                    case nameof(StreetName):
                        return StringValidator.IsLenghtCorrect(StreetName, 255);
                    case nameof(PostCode):
                        return StringValidator.IsLenghtCorrect(PostCode, 255);
                    case nameof(City):
                        return StringValidator.IsLenghtCorrect(City, 255);
                    case nameof(Country):
                        return StringValidator.IsLenghtCorrect(Country, 255);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Constructor

        public NewCustomerAddressesViewModel()
           : base("CustomerAddresses")
        {
            Item = new CustomerAddresses();
        }

        #endregion

        #region Methods
        protected override bool IsValid()
        {
            return this[nameof(HouseNumber)] == string.Empty
                && this[nameof(StreetName)] == string.Empty
                && this[nameof(PostCode)] == string.Empty
                && this[nameof(City)] == string.Empty
                && this[nameof(Country)] == string.Empty;
        }

        public override void Save()
        {
            try
            {
                Db.CustomerAddresses.AddObject(Item);
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

using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewEmployeeAddressesViewModel : AddRowViewModel<EmployeeAddresses>, IDataErrorInfo
    {
        #region Properties

        public string Flatnumber
        {
            get
            {
                return Item.Flatnumber;
            }
            set
            {
                if (value != Item.Flatnumber)
                {
                    Item.Flatnumber = value;
                    OnPropertyChanged(() => Flatnumber);
                }
            }
        }
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
                    case nameof(Flatnumber):
                        return StringValidator.IsLenghtCorrect(Flatnumber, 20);
                    case nameof(HouseNumber):
                        return StringValidator.IsLenghtCorrect(HouseNumber, 20);
                    case nameof(StreetName):
                        return StringValidator.IsLenghtCorrect(StreetName, 50);
                    case nameof(PostCode):
                        return StringValidator.IsLenghtCorrect(PostCode, 20);
                    case nameof(City):
                        return StringValidator.IsLenghtCorrect(City, 50);
                    case nameof(Country):
                        return StringValidator.IsLenghtCorrect(Country, 50);
                    default:
                        return string.Empty;
                }
            }
        }

        #endregion

        #region Constructor

        public NewEmployeeAddressesViewModel()
            :base("EmployeeAddresses")
        {
            Item = new EmployeeAddresses();
        }

        #endregion

        #region Methods
        protected override bool IsValid()
        {
            return this[nameof(Flatnumber)] == string.Empty
                && this[nameof(HouseNumber)] == string.Empty
                && this[nameof(StreetName)] == string.Empty
                && this[nameof(City)] == string.Empty
                && this[nameof(Country)] == string.Empty
                && this[nameof(PostCode)] == string.Empty;
        }
        public override void Save()
        {
            try
            {
                Db.EmployeeAddresses.AddObject(Item);
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

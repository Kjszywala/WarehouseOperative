using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewEmployeeAddressesViewModel : AddRowViewModel<EmployeeAddresses>
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

        #endregion

        #region Constructor

        public NewEmployeeAddressesViewModel()
            :base("EmployeeAddresses")
        {
            Item = new EmployeeAddresses();
        }

        #endregion

        #region Methods

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

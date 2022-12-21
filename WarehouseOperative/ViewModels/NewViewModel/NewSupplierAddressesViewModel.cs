using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewSupplierAddressesViewModel: AddRowViewModel<SupplierAddresses>
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
        #endregion

        #region Save
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

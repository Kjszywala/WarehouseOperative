using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows;
using WarehouseOperative.Models.DatabaseEntities;
using WarehouseOperative.Models.Validators;
using WarehouseOperative.ViewModels.Abstract;

namespace WarehouseOperative.ViewModels.NewViewModel
{
    public class NewCustomerViewModel : AddRowViewModel<Customers>, IDataErrorInfo
    {
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
        public string FirstName
        {
            get
            {
                return Item.FirstName;
            }
            set
            {
                if (value != Item.FirstName)
                {
                    Item.FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }
        public string SecondName
        {
            get
            {
                return Item.SecondName;
            }
            set
            {
                if (value != Item.SecondName)
                {
                    Item.SecondName = value;
                    OnPropertyChanged(() => SecondName);
                }
            }
        }
        public int? CustomerAddressId
        {
            get
            {
                return Item.CustomerAddressId;
            }
            set
            {
                if (value != Item.CustomerAddressId)
                {
                    Item.CustomerAddressId = value;
                    OnPropertyChanged(() => CustomerAddressId);
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return Item.PhoneNumber;
            }
            set
            {
                if (value != Item.PhoneNumber)
                {
                    Item.PhoneNumber = value;
                    OnPropertyChanged(() => PhoneNumber);
                }
            }
        }
        public string CustomerAddress { get; set; }
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CompanyName):
                        return StringValidator.IsLenghtCorrect(CompanyName, 255);
                    case nameof(FirstName):
                        return StringValidator.IsLenghtCorrect(FirstName, 255);
                    case nameof(SecondName):
                        return StringValidator.IsLenghtCorrect(SecondName, 255);
                    case nameof(PhoneNumber):
                        return StringValidator.IsLenghtCorrect(PhoneNumber, 255);
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Constructor

        public NewCustomerViewModel()
            : base("Customers")
        {
            Item = new Customers()
            {
                IsActive = true,
                Title = "New Customer",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
            Messenger.Default.Register<CustomerAddresses>(this, GetCustomerAddress);
        }

        #endregion

        #region Methods

        private void GetCustomerAddress(CustomerAddresses item)
        {
            CustomerAddress = $"Postcode: {item.PostCode}, City: {item.City}, Country: {item.Country}";
            CustomerAddressId = item.Id;
        }

        public override void Save()
        {
            try
            {
                Db.Customers.AddObject(Item);
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
